using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class KeepAliveMessage : Message
    {
        public KeepAliveMessage(Device Device, SCReader SCReader) : base(Device, SCReader)
        {
        }

        internal override void Process()
        {
            new KeepAliveOkMessage(Device).Send();
        }
    }
}