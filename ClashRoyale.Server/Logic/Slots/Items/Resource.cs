using Newtonsoft.Json;

namespace ClashRoyale.Server.Logic.Slots.Items
{
    internal class Resource
    {
        [JsonProperty("c")] internal int Count;
        [JsonProperty("d")] internal int Data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        internal Resource()
        {
            // Resource.
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Resource" /> class.
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="Value">The value.</param>
        internal Resource(int Data, int Count)
        {
            this.Data = Data;
            this.Count = Count;
        }
    }
}