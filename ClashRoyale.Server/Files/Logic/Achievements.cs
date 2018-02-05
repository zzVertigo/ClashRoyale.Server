using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Achievements : Data
    {
        public Achievements(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public string TID { get; set; }

        public string InfoTID { get; set; }

        public string Action { get; set; }

        public int ActionCount { get; set; }

        public int ExpReward { get; set; }

        public int DiamondReward { get; set; }

        public int SortIndex { get; set; }

        public bool Hidden { get; set; }

        public string AndroidID { get; set; }

        public string Type { get; set; }
    }
}