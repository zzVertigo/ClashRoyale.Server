using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Commands.Server;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class NameChangeMessage : Message
    {
        internal string Name;

        public NameChangeMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {

        }

        internal override void Decode()
        {
            this.Name = this.Reader.ReadString();
            this.Reader.ReadByte();
        }

        internal override void Process()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                if (this.Name.Length >= 2 && this.Name.Length <= 20)
                {
                    this.Device.Player.Username = this.Name;
                    this.Device.Player.NameState = 1;

                    new ServerCommandMessage(this.Device, new NameChangeCallback(this.Device, this.Name, string.Empty)).Send();

                    Resources.Players.Save(this.Device.Player);
                }
            }
        }
    }
}