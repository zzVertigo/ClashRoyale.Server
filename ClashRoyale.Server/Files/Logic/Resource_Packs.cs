using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Resource_Packs : Data
    {
        public Resource_Packs(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string Resource { get; set; }

        public int Amount { get; set; }

        public string IconFile { get; set; }
    }
}