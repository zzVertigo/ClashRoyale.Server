using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Logic.Enums;
using ClashRoyale.Server.Packets;

namespace ClashRoyale.Server.Networking
{
    internal class TCPServer
    {
        internal Socket Listener;
        internal SocketAsyncEventArgsPool ReadPool;
        internal SocketAsyncEventArgsPool WritePool;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TCPServer" /> class.
        /// </summary>
        internal TCPServer()
        {
            ReadPool = new SocketAsyncEventArgsPool(Settings.MaxPlayers);
            WritePool = new SocketAsyncEventArgsPool(Settings.MaxSends);

            Initialize();

            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Listener.ReceiveBufferSize = Settings.ReceiveBuffer;
            Listener.SendBufferSize = Settings.SendBuffer;

            Listener.Blocking = false;
            Listener.NoDelay = true;

            Listener.Bind(new IPEndPoint(IPAddress.Any, 9339));
            Listener.Listen(300);

            Console.WriteLine("TCP Server is listening on " + Listener.LocalEndPoint + ".");

            var AcceptEvent = new SocketAsyncEventArgs();
            AcceptEvent.Completed += OnAcceptCompleted;

            StartAccept(AcceptEvent);
        }

        /// <summary>
        ///     Initializes the read and write pools.
        /// </summary>
        internal void Initialize()
        {
            for (var Index = 0; Index < Settings.MaxPlayers; Index++)
            {
                var ReadEvent = new SocketAsyncEventArgs();

                ReadEvent.SetBuffer(new byte[Settings.ReceiveBuffer], 0, Settings.ReceiveBuffer);

                ReadEvent.Completed += OnReceiveCompleted;
                ReadEvent.DisconnectReuseSocket = true;

                ReadPool.Enqueue(ReadEvent);
            }

            for (var Index = 0; Index < Settings.MaxSends; Index++)
            {
                var WriteEvent = new SocketAsyncEventArgs();

                WriteEvent.Completed += OnSendCompleted;
                WriteEvent.DisconnectReuseSocket = true;

                WritePool.Enqueue(WriteEvent);
            }
        }

        /// <summary>
        ///     Accepts a TCP Request.
        /// </summary>
        /// <param name="AcceptEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void StartAccept(SocketAsyncEventArgs AcceptEvent)
        {
            AcceptEvent.AcceptSocket = null;
            AcceptEvent.RemoteEndPoint = null;

            if (!Listener.AcceptAsync(AcceptEvent)) OnAcceptCompleted(null, AcceptEvent);
        }

        /// <summary>
        ///     Called when the client has been accepted.
        /// </summary>
        /// <param name="Sender">The sender.</param>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void OnAcceptCompleted(object Sender, SocketAsyncEventArgs AsyncEvent)
        {
            if (AsyncEvent.SocketError == SocketError.Success)
            {
                ProcessAccept(AsyncEvent);
            }
            else
            {
                AsyncEvent.AcceptSocket.Close();

                Debug.WriteLine("[*] " + GetType().Name + " : " +
                                "Something happened when accepting a new connection, aborting.");

                StartAccept(AsyncEvent);
            }
        }

        /// <summary>
        ///     Accept the new client and store it in memory.
        /// </summary>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void ProcessAccept(SocketAsyncEventArgs AsyncEvent)
        {
            var Socket = AsyncEvent.AcceptSocket;

#if CHRONO
            Performance Chrono = new Performance();
#endif

            if (Socket.Connected)
            {
                var ReadEvent = ReadPool.Dequeue();

                if (ReadEvent == null)
                {
                    ReadEvent = new SocketAsyncEventArgs();

                    ReadEvent.SetBuffer(new byte[Settings.ReceiveBuffer], 0, Settings.ReceiveBuffer);
                    ReadEvent.Completed += OnReceiveCompleted;

                    ReadEvent.DisconnectReuseSocket = false;
                }

                Debug.WriteLine("Networking::Gateway - New connection: " + Socket.RemoteEndPoint + "!\n");

                var Device = new Device(Socket);
                var Token = new Token(ReadEvent, Device);

                if (!Socket.ReceiveAsync(ReadEvent)) ProcessReceive(ReadEvent);
            }
            else
            {
                Socket.Close();
            }

#if CHRONO
            TimeSpan TimeTaken = Chrono.Stop();

            if (TimeTaken.TotalSeconds > 1.0)
            {
                Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Took " + TimeTaken.TotalSeconds + " seconds to accept a client.");
            }
#endif

            StartAccept(AsyncEvent);
        }

        /// <summary>
        ///     Receives data from the specified client.
        /// </summary>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void ProcessReceive(SocketAsyncEventArgs AsyncEvent)
        {
            if (AsyncEvent.BytesTransferred > 0 && AsyncEvent.SocketError == SocketError.Success)
            {
                var Token = AsyncEvent.UserToken as Token;

                if (!Token.Aborting)
                {
                    Token.SetData();

                    try
                    {
                        if (Token.Device.Socket.Available == 0)
                        {
                            Token.Process();

                            if (!Token.Aborting)
                                if (!Token.Device.Socket.ReceiveAsync(AsyncEvent))
                                    ProcessReceive(AsyncEvent);
                        }
                        else
                        {
                            if (!Token.Device.Socket.ReceiveAsync(AsyncEvent)) ProcessReceive(AsyncEvent);
                        }
                    }
                    catch (Exception)
                    {
                        Disconnect(AsyncEvent);
                    }
                }
            }
            else
            {
                Disconnect(AsyncEvent);
            }
        }

        /// <summary>
        ///     Called when [receive completed].
        /// </summary>
        /// <param name="Sender">The sender.</param>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void OnReceiveCompleted(object Sender, SocketAsyncEventArgs AsyncEvent)
        {
            if (AsyncEvent.SocketError == SocketError.Success)
                ProcessReceive(AsyncEvent);
            else
                Disconnect(AsyncEvent);
        }

        /// <summary>
        ///     Sends the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        internal void Send(Message Message)
        {
            if (Message.Device.Connected)
            {
                var WriteEvent = WritePool.Dequeue();

                if (WriteEvent == null)
                    WriteEvent = new SocketAsyncEventArgs
                    {
                        DisconnectReuseSocket = false
                    };

                WriteEvent.SetBuffer(Message.ToBytes(), Message.Offset, Message.Length + 7 - Message.Offset);

                WriteEvent.AcceptSocket = Message.Device.Socket;
                WriteEvent.RemoteEndPoint = Message.Device.Socket.RemoteEndPoint;
                WriteEvent.UserToken = Message.Device.Token;

                if (!Message.Device.Socket.SendAsync(WriteEvent)) ProcessSend(Message, WriteEvent);
            }
            else
            {
                Disconnect(Message.Device.Token.Args);
            }
        }

        /// <summary>
        ///     Processes to send the specified message using the specified SocketAsyncEventArgs.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="Args">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void ProcessSend(Message Message, SocketAsyncEventArgs Args)
        {
            if (Args.SocketError == SocketError.Success)
            {
                Message.Offset += Args.BytesTransferred;

                if (Message.Length + 7 > Message.Offset)
                    if (Message.Device.Connected)
                    {
                        Args.SetBuffer(Message.Offset, Message.Length + 7 - Message.Offset);

                        if (!Message.Device.Socket.SendAsync(Args)) ProcessSend(Message, Args);
                    }
                    else
                    {
                        OnSendCompleted(null, Args);
                        Disconnect(Message.Device.Token.Args);
                    }
                else
                    OnSendCompleted(null, Args);
            }
            else
            {
                OnSendCompleted(null, Args);
                Disconnect(Message.Device.Token.Args);
            }
        }

        /// <summary>
        ///     Called when [send completed].
        /// </summary>
        /// <param name="Sender">The sender.</param>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void OnSendCompleted(object Sender, SocketAsyncEventArgs AsyncEvent)
        {
            if (AsyncEvent.DisconnectReuseSocket)
            {
                WritePool.Enqueue(AsyncEvent);
            }
            else
            {
                AsyncEvent.Dispose();
                AsyncEvent = null;
            }
        }

        /// <summary>
        ///     Closes the specified client's socket.
        /// </summary>
        /// <param name="AsyncEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        internal void Disconnect(SocketAsyncEventArgs AsyncEvent)
        {
            Console.WriteLine("Player disconnected!");

            var Token = AsyncEvent.UserToken as Token;

            if (Token.Aborting) return;

            Token.Aborting = true;

            Resources.Players.Save(Token.Device.Player);

            if (Token.Device.Player != null) Resources.Players.Remove(Token.Device.Player);

            Token.Device.Socket.Close();

            Token.Device.State = State.DISCONNECTED;

            if (AsyncEvent.DisconnectReuseSocket)
            {
                ReadPool.Enqueue(AsyncEvent);
            }
            else
            {
                AsyncEvent.Dispose();
                AsyncEvent = null;
            }
        }
    }
}