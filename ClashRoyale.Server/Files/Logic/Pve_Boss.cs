using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Pve_Boss : Data
    {
        public Pve_Boss(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string Waves { get; set; }

        public int WaveDuration { get; set; }

        public bool Repeat { get; set; }
    }
}