using System;
using System.Collections.Generic;
using System.Net.Sockets;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;

namespace ClashRoyale.Server.Networking
{
    internal class Token : IDisposable
    {
        internal bool Aborting;
        internal SocketAsyncEventArgs Args;

        internal byte[] Buffer;
        internal Device Device;
        internal bool Disposed;
        internal List<byte> Packet;

        internal int Tries;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Token" /> class.
        /// </summary>
        /// <param name="Args">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        /// <param name="Device">The device.</param>
        internal Token(SocketAsyncEventArgs Args, Device Device)
        {
            this.Device = Device;
            this.Device.Token = this;

            this.Args = Args;
            this.Args.UserToken = this;

            Buffer = new byte[Settings.ReceiveBuffer];
            Packet = new List<byte>(Settings.ReceiveBuffer);
        }

        /// <summary>
        ///     Exécute les tâches définies par l'application associées à la libération ou à la redéfinition des ressources non
        ///     managées.
        /// </summary>
        public void Dispose()
        {
            Buffer = null;
            Packet = null;
            Device = null;

            Tries = 0;

            Disposed = true;
        }

        /// <summary>
        ///     Sets the data.
        /// </summary>
        internal void SetData()
        {
            if (!Disposed)
            {
                var Data = new byte[Args.BytesTransferred];
                Array.Copy(Args.Buffer, 0, Data, 0, Args.BytesTransferred);
                Packet.AddRange(Data);
            }

            Tries += 1;
        }

        /// <summary>
        ///     Processes this instance.
        /// </summary>
        internal void Process()
        {
            if (Tries > 10)
            {
                Resources.Gateway.Disconnect(Args);
            }
            else
            {
                Tries = 0;

                var Data = Packet.ToArray();
                Device.Process(Data);
            }
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="Token" /> class.
        /// </summary>
        ~Token()
        {
            if (!Aborting) Resources.Gateway.Disconnect(Args);

            if (!Disposed) Dispose();

            GC.SuppressFinalize(this);
        }
    }
}