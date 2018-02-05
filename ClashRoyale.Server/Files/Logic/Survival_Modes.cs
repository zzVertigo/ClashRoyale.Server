using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Survival_Modes : Data
    {
        public Survival_Modes(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string GameMode { get; set; }

        public string WinsIconExportName { get; set; }

        public bool Enabled { get; set; }

        public bool EventOnly { get; set; }

        public int JoinCost { get; set; }

        public string JoinCostResource { get; set; }

        public int FreePass { get; set; }

        public int MaxWins { get; set; }

        public int MaxLoss { get; set; }

        public int RewardCards { get; set; }

        public int RewardGold { get; set; }

        public int RewardSpellCount { get; set; }

        public string RewardSpell { get; set; }

        public int RewardSpellMaxCount { get; set; }

        public string ItemExportName { get; set; }

        public string ConfirmExportName { get; set; }

        public string TID { get; set; }

        public string CardTheme { get; set; }
    }
}