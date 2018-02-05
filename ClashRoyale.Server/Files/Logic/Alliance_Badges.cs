using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Alliance_Badges : Data
    {
        public Alliance_Badges(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public string Category { get; set; }
    }
}