using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Npcs : Data
    {
        public Npcs(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Location { get; set; }

        public string PredefinedDeck { get; set; }

        public int Trophies { get; set; }

        public int ManaRegenMs { get; set; }

        public int ManaRegenMsEnd { get; set; }

        public int ManaRegenMsOvertime { get; set; }

        public int ExpLevel { get; set; }

        public bool CanReplay { get; set; }

        public string TID { get; set; }

        public int ExpReward { get; set; }

        public int Seed { get; set; }

        public bool FullDeckNotNeeded { get; set; }

        public int ManaReserve { get; set; }

        public int StartingMana { get; set; }

        public int WizardHpMultiplier { get; set; }

        public string StartTaunt { get; set; }

        public string OwnTowerDestroyedTaunt { get; set; }

        public bool HighlightTargetsOnManaFull { get; set; }

        public bool TrainingMatchAllowed { get; set; }
    }
}