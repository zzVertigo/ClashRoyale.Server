using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Abilities : Data
    {
        public Abilities(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string IconFile { get; set; }

        public string TID { get; set; }

        public string AreaEffectObject { get; set; }

        public string Buff { get; set; }

        public int BuffTime { get; set; }

        public string Effect { get; set; }
    }
}