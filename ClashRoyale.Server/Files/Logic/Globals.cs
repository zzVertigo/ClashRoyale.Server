using System.Collections.Generic;
using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Globals : Data
    {
        public Globals(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public int NumberValue { get; set; }

        public bool BooleanValue { get; set; }

        public string TextValue { get; set; }

        public List<string> StringArray { get; set; }

        public List<int> NumberArray { get; set; }
    }
}