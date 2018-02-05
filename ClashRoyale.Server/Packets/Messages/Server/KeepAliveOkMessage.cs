using ClashRoyale.Server.Logic;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class KeepAliveOkMessage : Message
    {
        public KeepAliveOkMessage(Device Device) : base(Device)
        {
            PacketID = 24135;
        }
    }
}