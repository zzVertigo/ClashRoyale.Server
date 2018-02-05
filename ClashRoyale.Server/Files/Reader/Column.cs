using System.Collections.Generic;
using System.Linq;

namespace ClashRoyale.Server.Files.Reader
{
    internal class Column
    {
        internal readonly List<string> Values;

        internal Column()
        {
            Values = new List<string>();
        }

        internal static int GetArraySize(int _Offset, int _NOffset)
        {
            return _NOffset - _Offset;
        }

        internal void Add(string _Value)
        {
            if (_Value == null)
                Values.Add(Values.Count > 0 ? Values.Last() : string.Empty);
            else
                Values.Add(_Value);
        }

        internal string Get(int _Row)
        {
            return Values[_Row];
        }

        internal int GetSize()
        {
            return Values.Count;
        }
    }
}