using ClashRoyale.Server.Logic;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class OwnHomeDataMessage : Message
    {
        public OwnHomeDataMessage(Device Device) : base(Device)
        {
            PacketID = 28502;
        }

        internal override void Encode()
        {
            this.Data.AddRange(this.Device.Player.LogicHome.ToBytes);
            this.Data.AddRange(this.Device.Player.LogicAvatar.ToBytes);
        }
    }
}