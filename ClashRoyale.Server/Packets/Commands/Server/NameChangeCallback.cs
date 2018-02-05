using System;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Commands.Server
{
    internal class NameChangeCallback : Command
    {
        private string Name;
        private string Previous;

        public NameChangeCallback(SCReader Reader, Device Device, int Identifier) : base(Reader, Device, Identifier)
        {
            
        }

        public NameChangeCallback(Device Device, string NewName, string Previous) : base(Device)
        {
            this.Identifier = 278;
        }

        internal override void Decode()
        {
            this.Name = this.Reader.ReadString();
            this.Previous = this.Reader.ReadString();

            this.Reader.Read();
            this.Reader.Read();

            this.ReadHeader();
        }

        internal override void Encode()
        {
            this.Data.AddString(this.Device.Player.Username);
            this.Data.AddString(this.Previous);

            this.Data.Add(0x7F);
            this.Data.Add(0x7F);

            this.Data.AddVInt(this.SubTick1);
            this.Data.AddVInt(this.SubTick2);
            this.Data.AddVInt(this.Device.Player.HighID);
            this.Data.AddVInt(this.Device.Player.LowID);
        }

        internal override void Process()
        {
            Console.WriteLine("Name: " + this.Name);
        }
    }
}