using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Event_Targeting_Definitions : Data
    {
        public Event_Targeting_Definitions(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string MetadataType { get; set; }

        public string MetadataPath { get; set; }

        public string EvaluationLocation { get; set; }

        public string ParameterName { get; set; }

        public string ParameterType { get; set; }

        public bool IsRequired { get; set; }

        public string ObjectType { get; set; }

        public string MatchingRuleType { get; set; }
    }
}