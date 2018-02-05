using System.Collections.Generic;
using System.IO;

namespace ClashRoyale.Server.Files.Reader
{
    public class Table
    {
        internal readonly List<Column> Columns;
        internal readonly List<string> Headers;
        internal readonly List<Row> Rows;
        internal readonly List<string> Types;

        public Table(string _Path)
        {
            Rows = new List<Row>();
            Headers = new List<string>();
            Types = new List<string>();
            Columns = new List<Column>();

            using (var _Reader = new StreamReader(_Path))
            {
                var _Columns = _Reader.ReadLine().Replace("\"", string.Empty).Replace(" ", string.Empty).Split(',');
                foreach (var _Column in _Columns)
                {
                    Headers.Add(_Column);
                    Columns.Add(new Column());
                }

                var types = _Reader.ReadLine().Replace("\"", string.Empty).Split(',');
                foreach (var type in types) Types.Add(type);

                while (!_Reader.EndOfStream)
                {
                    var _Values = _Reader.ReadLine().Replace("\"", string.Empty).Split(',');

                    if (!string.IsNullOrEmpty(_Values[0])) new Row(this);

                    for (var i = 0; i < Headers.Count; i++) Columns[i].Add(_Values[i]);
                }
            }
        }

        public Row GetRowAt(int _Index)
        {
            return Rows[_Index];
        }

        public int GetRowCount()
        {
            return Rows.Count;
        }

        public string GetValue(string _Name, int _Level)
        {
            var _Index = Headers.IndexOf(_Name);
            return GetValueAt(_Index, _Level);
        }

        public string GetValueAt(int _Column, int _Row)
        {
            return Columns[_Column].Get(_Row);
        }

        internal void AddRow(Row _Row)
        {
            Rows.Add(_Row);
        }

        internal int GetArraySizeAt(Row row, int columnIndex)
        {
            var _Index = Rows.IndexOf(row);
            if (_Index == -1) return 0;

            var c = Columns[columnIndex];
            var _NextOffset = 0;
            if (_Index + 1 >= Rows.Count)
            {
                _NextOffset = c.GetSize();
            }
            else
            {
                var _NextRow = Rows[_Index + 1];
                _NextOffset = _NextRow.Offset;
            }

            var _Offset = row.Offset;
            return Column.GetArraySize(_Offset, _NextOffset);
        }

        internal int GetColumnIndexByName(string _Name)
        {
            return Headers.IndexOf(_Name);
        }

        internal string GetColumnName(int _Index)
        {
            return Headers[_Index];
        }

        internal int GetColumnRowCount()
        {
            if (Columns.Count > 0) return Columns[0].GetSize();

            return 0;
        }
    }
}