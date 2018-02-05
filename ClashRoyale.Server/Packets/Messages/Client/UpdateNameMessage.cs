using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Commands.Server;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class UpdateNameMessage : Message
    {
        private string Name;

        public UpdateNameMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {

        }

        internal override void Decode()
        {
            this.Name = Reader.ReadString();
        }

        internal override void Process()
        {
            this.Device.Player.Username = this.Name;

            new ServerCommandMessage(this.Device,
                new NameChangeCallback(this.Device, this.Name, this.Device.Player.Username)).Send();

            Resources.Players.Save(this.Device.Player);
        }
    }
}