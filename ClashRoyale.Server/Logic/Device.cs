using System;
using System.Diagnostics;
using System.Net.Sockets;
using ClashRoyale.Server.Library;
using ClashRoyale.Server.Logic.Enums;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Logic
{
    internal class Device
    {
        internal string AndroidID;
        internal Crypto Crypto;

        internal string Interface;

        internal bool isAndroid;
        internal string Model;
        internal string OpenUDID;
        internal string OSVersion;
        internal int Ping;
        internal Player Player;

        internal Socket Socket;

        internal State State = State.DISCONNECTED;
        internal Token Token;

        internal Device(Socket Socket)
        {
            this.Socket = Socket;

            Crypto = new Crypto();
        }

        internal Device(Socket Socket, Token Token)
        {
            this.Socket = Socket;
            this.Token = Token;

            Crypto = new Crypto();
        }

        internal string OS => isAndroid ? "Android" : "iOS";

        internal bool Connected
        {
            get
            {
                if (Socket.Connected)
                    try
                    {
                        if (!Socket.Poll(1000, SelectMode.SelectRead) || Socket.Available != 0) return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                return false;
            }
        }

        internal void Process(byte[] Data)
        {
            if (Data.Length >= 7)
                using (var Reader = new SCReader(Data))
                {
                    var PacketID = Reader.ReadInt16();
                    var Length = Reader.ReadInt24();
                    var Version = Reader.ReadInt16();

                    var Payload = Reader.ReadBytes(Length);

                    if (Length == Payload.Length)
                    {
                        Crypto.Decrypt(ref Payload);

                        if (Factory.Messages.ContainsKey(PacketID))
                        {
                            var Message =
                                (Message) Activator.CreateInstance(Factory.Messages[PacketID], this, Reader);

                            Message.PacketID = PacketID;
                            Message.Length = Length;
                            Message.Version = Version;

                            Message.Reader = new SCReader(Payload);

                            Debug.WriteLine("Device::Process - Handling packet " + PacketID + " (" +
                                            Message.GetMessageType() + ")");
                            Debug.WriteLine("Device::Process - Message Type: " + Tools.GetMessageDirection(PacketID) +
                                            "\n");

                            Message.Decode();
                            Message.Process();
                        }
                        else
                        {
                            Debug.WriteLine("Device::Process - Unable to handle packet " + PacketID);
                            Debug.WriteLine(
                                "Device::Process - Data: " + BitConverter.ToString(Payload).Replace("-", ""));
                            Debug.WriteLine("Device::Process - Message Type: " + Tools.GetMessageDirection(PacketID) +
                                            "\n");
                        }
                    }

                    if (!Token.Aborting)
                    {
                        Token.Packet.RemoveRange(0, Length + 7);

                        if (Data.Length - 7 - Length >= 7) Process(Reader.ReadBytes(Data.Length - 7 - Length));
                    }
                }
        }
    }
}