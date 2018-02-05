using System.Collections.Generic;
using ClashRoyale.Server.Files.Logic;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files.Helpers
{
    internal class DataTable
    {
        internal List<Data> Datas;
        internal int Index;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataTable" /> class.
        /// </summary>
        internal DataTable()
        {
            Datas = new List<Data>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataTable" /> class.
        /// </summary>
        /// <param name="Table">The table.</param>
        /// <param name="Index">The index.</param>
        public DataTable(Table Table, int Index)
        {
            this.Index = Index;
            Datas = new List<Data>();

            for (var i = 0; i < Table.GetRowCount(); i++)
            {
                var Row = Table.GetRowAt(i);
                var Data = Create(Row);

                Datas.Add(Data);
            }
        }

        /// <summary>
        ///     Creates the data for the specified row.
        /// </summary>
        /// <param name="Row">The row.</param>
        internal Data Create(Row Row)
        {
            Data Data;

            switch (Index)
            {
                case 1:
                {
                    Data = new Alliance_Badges(Row, this);
                    break;
                }

                case 2:
                {
                    Data = new Alliance_Roles(Row, this);
                    break;
                }

                case 3:
                {
                    Data = new Exp_Levels(Row, this);
                    break;
                }

                case 4:
                {
                    Data = new Globals(Row, this);
                    break;
                }

                case 5:
                {
                    Data = new Logic.Resources(Row, this);
                    break;
                }

                case 6:
                {
                    Data = new Npcs(Row, this);
                    break;
                }

                case 7:
                {
                    Data = new Predefined_Decks(Row, this);
                    break;
                }

                case 8:
                {
                    Data = new Rarities(Row, this);
                    break;
                }

                case 9:
                {
                    Data = new Chest_Order(Row, this);
                    break;
                }

                case 19:
                {
                    Data = new Treasure_Chests(Row, this);
                    break;
                }

                case 26:
                {
                    Data = new Spells_Characters(Row, this);
                    break;
                }

                case 27:
                {
                    Data = new Spells_Buildings(Row, this);
                    break;
                }

                case 28:
                {
                    Data = new Spells_Other(Row, this);
                    break;
                }

                // Broken
                //case 29:
                //    {
                //        Data = new Spells_Heroes(Row, this);
                //        break;
                //    }

                //case 54:
                //    {
                //        Data = new Arenas(Row, this);
                //        break;
                //    }

                case 55:
                {
                    Data = new Resource_Packs(Row, this);
                    break;
                }

                case 57:
                {
                    Data = new Regions(Row, this);
                    break;
                }

                case 60:
                {
                    Data = new Achievements(Row, this);
                    break;
                }

                case 66:
                {
                    Data = new Shop(Row, this);
                    break;
                }

                default:
                {
                    Data = new Data(Row, this);
                    break;
                }
            }

            return Data;
        }

        /// <summary>
        ///     Gets the data with identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        internal Data GetDataWithID(int ID)
        {
            return Datas[GlobalID.GetID(ID)];
        }

        /// <summary>
        ///     Gets the data with instance identifier.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        internal Data GetDataWithInstanceID(int ID)
        {
            return Datas[ID];
        }

        /// <summary>
        ///     Gets the data.
        /// </summary>
        /// <param name="Name">The name.</param>
        internal Data GetData(string Name)
        {
            return Datas.Find(Data => Data.Row.Name == Name);
        }
    }
}