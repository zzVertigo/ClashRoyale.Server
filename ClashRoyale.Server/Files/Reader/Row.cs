namespace ClashRoyale.Server.Files.Reader
{
    public class Row
    {
        public readonly int RowStart;
        public readonly Table Table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Row" /> class.
        /// </summary>
        /// <param name="Table">The table.</param>
        public Row(Table Table)
        {
            this.Table = Table;
            RowStart = this.Table.GetColumnRowCount();

            this.Table.AddRow(this);
        }

        /// <summary>
        ///     Gets the name of this row.
        /// </summary>
        public string Name => Table.GetValueAt(0, RowStart);

        /// <summary>
        ///     Gets the row offset.
        /// </summary>
        public int Offset => RowStart;

        public int GetArraySize(string Name)
        {
            var Index = Table.GetColumnIndexByName(Name);
            return Index != -1 ? Table.GetArraySizeAt(this, Index) : 0;
        }

        public string GetValue(string Name, int Level)
        {
            return Table.GetValue(Name, Level + RowStart);
        }
    }
}