using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Game_Modes : Data
    {
        public Game_Modes(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string RequestTID { get; set; }

        public string InProgressTID { get; set; }

        public string CardLevelAdjustment { get; set; }

        public int PlayerCount { get; set; }

        public string DeckSelection { get; set; }

        public int OvertimeSeconds { get; set; }

        public string PredefinedDecks { get; set; }

        public int ElixirProductionMultiplier { get; set; }

        public int ElixirProductionOvertimeMultiplier { get; set; }

        public bool UseStartingElixir { get; set; }

        public int StartingElixir { get; set; }

        public bool Heroes { get; set; }

        public string ForcedDeckCards { get; set; }

        public string Players { get; set; }

        public string EventDeckSetLimit { get; set; }

        public bool ForcedDeckCardsUsingCardTheme { get; set; }

        public string PrincessSkin { get; set; }

        public string KingSkin { get; set; }

        public bool GivesClanScore { get; set; }
    }
}