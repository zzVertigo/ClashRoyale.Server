using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Draft_Deck : Data
    {
        public Draft_Deck(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string RequiredSets { get; set; }

        public string OptionalSets { get; set; }
    }
}