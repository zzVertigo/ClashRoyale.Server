using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Pve_Gamemodes : Data
    {
        public Pve_Gamemodes(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Waves { get; set; }

        public string VictoryCondition { get; set; }

        public string ForcedCards { get; set; }

        public string Location { get; set; }

        public string ComputerPlayerType { get; set; }

        public string TowerRules { get; set; }
    }
}