using Newtonsoft.Json;

namespace ClashRoyale.Server.Managers
{
    internal class ReplayManager
    {
        [JsonProperty("arena")] internal int Arena;
        [JsonProperty("data")] internal string JSON;
        [JsonProperty("replay_id")] internal long ReplayID;
        [JsonProperty("view_count")] internal int ViewCount;
    }
}