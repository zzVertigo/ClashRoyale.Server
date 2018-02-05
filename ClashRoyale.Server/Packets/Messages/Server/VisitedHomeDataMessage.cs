using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class VisitedHomeDataMessage : Message
    {
        internal Player Player;

        public VisitedHomeDataMessage(Device Device, Player Player) : base(Device)
        {
            this.PacketID = 25880;
            this.Player = Player;
        }

        internal override void Encode()
        {
            Data.AddByte(0x06);
            Data.AddByte(0x00);
            Data.AddByte(0x7F);

            Data.AddHexa("00 01 00 00 01 00 00 00 00 02 00 00 01 00 00 00 00 0E 00 00 01 00 00 00 00 8F 01 00 00 01 00 00 00 00 8E 01 00 00 01 00 00 00 00 04 00 00 01 00 00 00 00");

            Data.AddInt64(Player.UserID);
            Data.Add(0x00);
            Data.Add(0x00);
            Data.Add(0x01);
            Data.AddRange(Player.LogicAvatar.ToBytes);
            Data.Add(5);
            Data.AddRange(Player.LogicAvatar.ToBytes);
            Data.Add(0);
        }
    }
}