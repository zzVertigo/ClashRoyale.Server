using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Tournament_Tiers : Data
    {
        public Tournament_Tiers(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public int Version { get; set; }

        public bool Disabled { get; set; }

        public int CreateCost { get; set; }

        public int MaxPlayers { get; set; }

        public int Prize1 { get; set; }

        public int Prize2 { get; set; }

        public int Prize3 { get; set; }

        public int Prize10 { get; set; }

        public int Prize20 { get; set; }

        public int Prize30 { get; set; }

        public int Prize40 { get; set; }

        public int Prize50 { get; set; }

        public int Prize60 { get; set; }

        public int Prize70 { get; set; }

        public int Prize80 { get; set; }

        public int Prize90 { get; set; }

        public int Prize100 { get; set; }

        public int Prize150 { get; set; }

        public int Prize200 { get; set; }

        public int Prize250 { get; set; }

        public int Prize300 { get; set; }

        public int Prize350 { get; set; }

        public int Prize400 { get; set; }

        public int Prize450 { get; set; }

        public int Prize500 { get; set; }

        public int OpenChestVariation { get; set; }
    }
}