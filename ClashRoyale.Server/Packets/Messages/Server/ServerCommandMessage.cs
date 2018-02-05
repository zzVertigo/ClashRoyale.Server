using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class ServerCommandMessage : Message
    {
        private readonly Command Command;

        public ServerCommandMessage(Device Device, Command Command) : base(Device)
        {
            this.PacketID = 23394;

            this.Command = Command.Handle();
        }

        internal override void Encode()
        {
            this.Data.AddRange(this.Command.ToBytes);
        }
    }
}