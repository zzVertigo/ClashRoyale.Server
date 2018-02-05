using ClashRoyale.Server.Database;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Server
{
    internal class RoyalTVContentMessage : Message
    {
        private readonly int ID;

        private readonly int Type = 54;

        public RoyalTVContentMessage(Device Device, int ID) : base(Device)
        {
            PacketID = 20073;

            this.ID = ID;
        }

        internal override void Encode()
        {
            //var i = 0;
            //var v = 0;

            //if (ID == MySQL.GetReplays[i].Arena) v++;

            // Count
            Data.AddVInt(0);

            //if (v > 0)
            //{
            //    foreach (var Replay in MySQL.GetReplays)
            //        if (ID == Replay.Arena)
            //        {
            //            Data.AddString(Replay.JSON);

            //            Data.AddBoolean(true);

            //            Data.AddVInt(0);
            //            Data.AddVInt(0);
            //            Data.AddVInt(0);

            //            Data.AddVInt(Replay.ViewCount); // View Count

            //            Data.AddVInt(0);
            //            Data.AddVInt(1);

            //            Data.AddVInt(0); // Age Seconds
            //            Data.AddVInt(0); // Running ID

            //            Data.AddBoolean(Replay.ReplayID != 0); // If Replay ID != 0

            //            Data.AddVInt(0x36);

            //            Data.AddInt64(Replay.ReplayID);

            //            i++;
            //        }
            //}

            Data.AddVInt(Type); // Arena Type
            Data.AddVInt(ID); // Arena ID
        }
    }
}