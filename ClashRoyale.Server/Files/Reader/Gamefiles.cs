using System.Collections.Generic;
using ClashRoyale.Server.Files.Helpers;
using ClashRoyale.Server.Logic.Enums;

namespace ClashRoyale.Server.Files.Reader
{
    internal class Gamefiles
    {
        internal readonly Dictionary<int, DataTable> DataTables;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gamefiles" /> class.
        /// </summary>
        internal Gamefiles()
        {
            DataTables = new Dictionary<int, DataTable>(CSV.Gamefiles.Count);
        }

        /// <summary>
        ///     Gets the <see cref="DataTable" /> at the specified index.
        /// </summary>
        /// <param name="Index">The index.</param>
        internal DataTable Get(int Index)
        {
            return DataTables[Index];
        }

        /// <summary>
        ///     Gets the <see cref="DataTable" /> at the specified index.
        /// </summary>
        /// <param name="Index">The index.</param>
        internal DataTable Get(Gamefile Index)
        {
            return DataTables[(int) Index];
        }

        /// <summary>
        ///     Gets the with global identifier.
        /// </summary>
        /// <param name="GlobalID">The global identifier.</param>
        /// <returns></returns>
        internal Data GetWithGlobalID(int GlobalID)
        {
            var Type = 0;

            while (GlobalID >= 1000000)
            {
                Type += 1;
                GlobalID -= 1000000;
            }

            return DataTables[Type].GetDataWithInstanceID(GlobalID);
        }

        /// <summary>
        ///     Initializes the specified table.
        /// </summary>
        /// <param name="Table">The table.</param>
        /// <param name="Index">The index.</param>
        internal void Initialize(Table Table, int Index)
        {
            DataTables.Add(Index, new DataTable(Table, Index));
        }
    }
}