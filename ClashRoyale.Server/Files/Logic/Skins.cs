using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Skins : Data
    {
        public Skins(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string FileName { get; set; }

        public string ExportName { get; set; }

        public string ExportNameRed { get; set; }

        public string TopExportName { get; set; }

        public string TopExportNameRed { get; set; }

        public string Category { get; set; }

        public int ValueGems { get; set; }

        public string TID { get; set; }

        public string IconSWF { get; set; }

        public string IconExportName { get; set; }

        public bool IsInUse { get; set; }

        public string Type { get; set; }
    }
}