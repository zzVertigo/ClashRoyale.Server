using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Pve_Waves : Data
    {
        public Pve_Waves(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Spells { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public int Delay { get; set; }
    }
}