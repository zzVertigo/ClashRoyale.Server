using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Logic
{
    internal class Event_Category_Object_Definitions : Data
    {
        public Event_Category_Object_Definitions(Row Row, DataTable DataTable) : base(Row, DataTable)
        {
            Load(this, GetType(), Row);
        }

        public string Name { get; set; }

        public string PropertyName { get; set; }

        public string PropertyType { get; set; }

        public bool IsRequired { get; set; }

        public string ObjectType { get; set; }

        public int DefaultInt { get; set; }

        public string DefaultString { get; set; }
    }
}