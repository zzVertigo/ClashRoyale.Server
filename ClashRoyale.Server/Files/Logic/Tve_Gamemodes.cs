using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Tve_Gamemodes : Data
    {
        public Tve_Gamemodes(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string PrimarySpells { get; set; }

        public string SecondarySpells { get; set; }

        public string CastSpells { get; set; }

        public bool RandomWaves { get; set; }

        public int ElixirPerWave { get; set; }

        public int WaveCount { get; set; }

        public int TimePerWave { get; set; }

        public int TimeToFirstWave { get; set; }

        public string ForcedCards1 { get; set; }

        public string ForcedCards2 { get; set; }

        public bool RotateDecks { get; set; }
    }
}