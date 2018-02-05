using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Exp_Levels : Data
    {
        public Exp_Levels(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public int ExpToNextLevel { get; set; }

        public int SummonerLevel { get; set; }

        public int TowerLevel { get; set; }

        public int TroopLevel { get; set; }

        public int Decks { get; set; }

        public int SummonerKillGold { get; set; }

        public int TowerKillGold { get; set; }

        public int DiamondReward { get; set; }
    }
}