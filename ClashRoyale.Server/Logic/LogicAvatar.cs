using System;
using System.Collections.Generic;
using System.Text;
using ClashRoyale.Server.Logic.Slots.Items;
using ClashRoyale.Server.Utilities;
using Newtonsoft.Json;

namespace ClashRoyale.Server.Logic
{
    internal class LogicAvatar
    {
        [JsonProperty("player")] internal Player Player;

        internal LogicAvatar()
        {

        }

        internal LogicAvatar(Player Player) : this()
        {
            this.Player = Player;
        }

        internal byte[] ToBytes
        {
            get
            {
                List<byte> Data = new List<byte>();

                Data.AddVInt(this.Player.LowID, this.Player.HighID);
                Data.AddVInt(this.Player.LowID, this.Player.HighID);
                Data.AddVInt(this.Player.LowID, this.Player.HighID);

                Data.AddString(this.Player.Username);

                Data.AddByte(0); // Name Change Count

                Data.AddByte(this.Player.Arena + 1); // Arena

                Data.AddVInt(this.Player.Trophies); // Trophies

                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);

                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);
                Data.AddVInt(0);

                Data.Add(8);

                Resource[] Normals = this.Player.Resources.Normals;

                Data.AddVInt(Normals.Length);

                foreach (Resource Resource in Normals)
                {
                    Data.AddData(Resource.Data);
                    Data.AddVInt(Resource.Count);
                }

                Data.AddVInt(0);

                Data.AddHexa("06 3C 04 01 3C 05 01 3C 06 01 3C 07 06 3C 08 06 3C 09 06 00 03 05 08 06 05 0B 27 "); // More dataslots...

                Data.AddVInt(0x05); // Count

                // Type, ID, Unknown

                Data.AddHexa("1B 01 05 1A 00 08 1A 01 08 1A 03 08 1A 0D 06 1C 00 03"); // Deck

                Data.AddVInt(0);
                Data.AddBoolean(false);

                Data.AddVInt(Player.Gems); // Gems
                Data.AddVInt(Player.FreeGems); // Free Gems

                Data.AddVInt(Player.Experience); // Experience
                Data.AddVInt(Player.Level); // Level

                Data.AddVInt(0);

                // 0 = You
                // 1 - 7 (Name Set)
                // 8 = Name Change
                // 9 = Tutorial Finished (Name Set)

                Data.AddByte(Player.NameState);

                Data.Add(0);

                Data.AddVInt(0); // Games
                Data.AddVInt(0); // Tournament Games
                Data.AddVInt(0); // Wins
                Data.AddVInt(0); // Loses
                Data.AddVInt(0); // Win Streak

                Data.AddByte(6); // Tutorial

                Data.AddBoolean(false); // Tournament

                Data.AddBoolean(false); // Challenges

                Data.AddVInt(0);

                Data.AddHexa("01 00 FB BC 91 9F 09 00 BD 02");

                return Data.ToArray();
            }
        }
    }
}