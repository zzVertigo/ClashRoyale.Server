using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Regions : Data
    {
        public Regions(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string DisplayName { get; set; }

        public bool IsCountry { get; set; }

        public bool RegionPopup { get; set; }
    }
}