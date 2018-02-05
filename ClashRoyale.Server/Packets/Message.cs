using System.Collections.Generic;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets
{
    internal class Message
    {
        internal List<byte> Data;

        internal Device Device;
        internal int Length;

        internal int Offset;
        internal short PacketID;
        internal SCReader Reader;
        internal short Version;

        internal Message(Device Device)
        {
            this.Device = Device;
            Data = new List<byte>(2048);
        }

        internal Message(Device Device, SCReader Reader)
        {
            this.Device = Device;
            this.Reader = Reader;
        }

        internal byte[] ToBytes()
        {
            var Data = new List<byte>();

            Data.AddInt16(PacketID);
            Data.AddInt24(Length);
            Data.AddInt16(Version);

            Data.AddRange(this.Data);

            return Data.ToArray();
        }

        internal string GetMessageType()
        {
            switch (PacketID)
            {
                // Client Messages

                case 10101:
                    return "LoginMessage";

                case 10185:
                    return "AskForTVContentMessage";

                case 11149:
                    return "AskForTopPlayersMessage";

                case 11688:
                    return "ClientCapabilitesMessage";

                case 18688:
                    return "EndClientTurnMessage";

                case 19911:
                    return "KeepAliveMessage";

                // Server Messages

                case 20073:
                    return "RoyalTVContentMessage";

                case 28502:
                    return "OwnHomeDataMessage";

                case 29733:
                    return "TopPlayersMessage";

                case 25880:
                    return "VisitedHomeDataMessage";

                case 22280:
                    return "LoginOkMessage";

                case 24135:
                    return "KeepAliveOkMessage";

                // --------------------------------------- //

                default:
                    return "Unknown Message";
            }
        }

        internal virtual void Decode()
        {
        }

        internal virtual void Encode()
        {
        }

        internal virtual void Process()
        {
        }

        internal virtual void Encrypt()
        {
            var Decrypted = Data.ToArray();

            Device.Crypto.Encrypt(ref Decrypted);

            Data = new List<byte>(Decrypted);
            Length = Data.Count;
        }
    }
}