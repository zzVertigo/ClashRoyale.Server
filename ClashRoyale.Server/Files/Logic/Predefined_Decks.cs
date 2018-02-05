using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Predefined_Decks : Data
    {
        public Predefined_Decks(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Spells { get; set; }

        public int SpellLevel { get; set; }

        public string RandomSpellSets { get; set; }

        public string Description { get; set; }

        public string TID { get; set; }
    }
}