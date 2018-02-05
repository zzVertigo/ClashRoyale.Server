namespace ClashRoyale.Server.Files.Helpers
{
    internal static class GlobalID
    {
        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <param name="GlobalID">The global identifier.</param>
        /// <returns></returns>
        internal static int GetType(int GlobalID)
        {
            return GlobalID / 1000000;
        }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <param name="GlobalID">The global identifier.</param>
        /// <returns></returns>
        internal static int GetID(int GlobalID)
        {
            return GlobalID - GetType(GlobalID) * 1000000;
        }

        /// <summary>
        ///     Creates the specified type.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <param name="ID">The identifier.</param>
        /// <returns></returns>
        internal static int Create(int Type, int ID)
        {
            return Type * 1000000 + ID;
        }

        /// <summary>
        ///     Creates the compressed.
        /// </summary>
        /// <param name="Data">The data.</param>
        /// <param name="BaseType">Type of the base.</param>
        /// <returns></returns>
        internal static int CreateCompressed(int Data, int BaseType)
        {
            var ID = GetID(Data) + 1;
            var Type = GetType(Data);

            if (Type > BaseType)
                while (Type > BaseType)
                    ID += CSV.Tables.Get(BaseType++).Datas.Count;

            return ID;
        }

        internal static int GetCompressed(int CID, int BaseType)
        {
            int CSVObjectCount;

            CID--;

            while (BaseType < 100)
                if (CID >= (CSVObjectCount = CSV.Tables.Get(BaseType).Datas.Count))
                {
                    BaseType++;

                    CID -= CSVObjectCount;
                }
                else
                {
                    break;
                }

            return BaseType * 1000000 + CID;
        }
    }
}