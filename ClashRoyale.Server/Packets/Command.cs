using System.Collections.Generic;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets
{
    internal class Command
    {
        internal int Identifier;

        internal int SubTick1;
        internal int SubTick2;

        internal int SubHighID;
        internal int SubLowID;

        internal SCReader Reader;
        internal Device Device;

        internal List<byte> Data;

        internal Command(Device Device)
        {
            this.Device = Device;
            this.Data = new List<byte>();
        }

        internal Command(SCReader Reader, Device Device, int Identifier)
        {
            this.Identifier = Identifier;
            this.Device = Device;
            this.Reader = Reader;

            this.Data = new List<byte>();
        }

        internal void ReadHeader()
        {
            this.SubTick1 = this.Reader.ReadVInt();
            this.SubTick2 = this.Reader.ReadVInt();
            this.SubHighID = this.Reader.ReadVInt();
            this.SubLowID = this.Reader.ReadVInt();
        }

        /// <summary>
        /// Decodes this instance.
        /// </summary>
        internal virtual void Decode()
        {
            // Decode.
        }

        /// <summary>
        /// Encodes this instance.
        /// </summary>
        internal virtual void Encode()
        {
            // Encode.
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        internal virtual void Process()
        {
            // Process.
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Packet = new List<byte>();

                Packet.AddVInt(this.Identifier);
                Packet.AddRange(this.Data);

                return Packet.ToArray();
            }
        }
    }
}