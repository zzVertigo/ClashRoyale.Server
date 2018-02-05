using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Content_Tests : Data
    {
        public Content_Tests(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string SourceData { get; set; }

        public string TargetData { get; set; }

        public string Stat1 { get; set; }

        public string Operator { get; set; }

        public string Stat2 { get; set; }

        public int Result { get; set; }

        public bool Enabled { get; set; }
    }
}