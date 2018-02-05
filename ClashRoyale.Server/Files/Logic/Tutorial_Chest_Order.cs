using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Tutorial_Chest_Order : Data
    {
        public Tutorial_Chest_Order(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Chest { get; set; }

        public string NPC { get; set; }

        public string PvE_Tutorial { get; set; }
    }
}