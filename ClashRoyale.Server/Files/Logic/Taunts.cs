using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Taunts : Data
    {
        public Taunts(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public bool TauntMenu { get; set; }

        public string FileName { get; set; }

        public string ExportName { get; set; }

        public string IconExportName { get; set; }

        public string BtnExportName { get; set; }

        public string Sound { get; set; }
    }
}