using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Event_Categories : Data
    {
        public Event_Categories(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string CSVFiles { get; set; }

        public string CSVRows { get; set; }

        public string CustomNames { get; set; }
    }
}