using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Resources : Data
    {
        public Resources(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string TID { get; set; }

        public string IconSWF { get; set; }

        public bool UsedInBattle { get; set; }

        public string CollectEffect { get; set; }

        public string IconExportName { get; set; }

        public bool PremiumCurrency { get; set; }

        public string CapFullTID { get; set; }

        public int TextRed { get; set; }

        public int TextGreen { get; set; }

        public int TextBlue { get; set; }

        public int Cap { get; set; }

        public string IconFile { get; set; }

        public string ShopIcon { get; set; }
    }
}