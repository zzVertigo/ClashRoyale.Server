using System.Collections.Generic;
using ClashRoyale.Server.Logic.Slots;
using ClashRoyale.Server.Logic.Slots.Items;
using ClashRoyale.Server.Managers;
using ClashRoyale.Server.Utilities;
using Newtonsoft.Json;

namespace ClashRoyale.Server.Logic
{
    internal class Player
    {
        internal Device Device;

        internal LogicHome LogicHome;
        internal LogicAvatar LogicAvatar;

        internal int HighID;
        internal int LowID;

        [JsonProperty("userid")] internal long UserID;

        [JsonProperty("username")] internal string Username;

        [JsonProperty("name_state")] internal int NameState = 8;

        [JsonProperty("passtoken")] internal string Token;

        // TODO: Evaluate trophy count and tutorial to determine actual arena.
        [JsonProperty("arena")] internal int Arena => 12;

        [JsonProperty("trophies")] internal int Trophies = 9999;

        [JsonProperty("level")] internal int Level = 13;
        [JsonProperty("experience")] internal int Experience;

        [JsonProperty("region")] internal string Region;
        [JsonProperty("country")] internal string Country;
        [JsonProperty("city")] internal string City;

        [JsonProperty("gems")] internal int Gems = 999999;
        [JsonProperty("free_gems")] internal int FreeGems = 999999;

        [JsonProperty("resources")] internal Resources Resources;

        public Player()
        {
            this.LogicHome = new LogicHome(this);
            this.LogicAvatar = new LogicAvatar(this);

            this.Resources = new Resources(this, true);
        }

        public Player(Device Device, long UserID) : this()
        {
            this.Device = Device;

            this.UserID = UserID;

            this.HighID = Tools.GetHighID(this.UserID);
            this.LowID = Tools.GetLowID(this.UserID);
        }
    }
}