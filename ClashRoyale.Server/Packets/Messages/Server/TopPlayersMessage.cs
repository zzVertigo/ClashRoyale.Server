using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Managers;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class TopPlayersMessage : Message
    {
        public TopPlayersMessage(Device Device) : base(Device)
        {
            PacketID = 29733;
        }

        internal override void Encode()
        {
            Data.AddVInt(Resources.Players.Count);

            var i = 1;

            foreach (var Player in Resources.Players.Values)
            {
                Data.AddVInt(Player.HighID);
                Data.AddVInt(Player.LowID);

                Data.AddString(Player.Username);

                Data.AddVInt(i);

                Data.AddVInt(Player.Trophies);

                Data.AddVInt(i++);

                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);

                Data.AddVInt(Player.Level);

                Data.AddInt32(0);
                Data.AddInt32(0);
                Data.AddInt32(0);
                Data.AddInt32(0);
                Data.AddInt32(0);

                Data.AddString("CA");

                Data.AddInt32(Player.HighID);
                Data.AddInt32(Player.LowID);

                Data.AddInt32(39);
                Data.AddInt32(0);

                Data.AddBoolean(false);
            }

            Data.AddInt32(0); // Last Season Count

            Data.AddInt32(TimeManager.GetRemainingSeasonTime); // Seconds
        }
    }
}