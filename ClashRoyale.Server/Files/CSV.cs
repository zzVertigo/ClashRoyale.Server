using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClashRoyale.Server.Files.Reader;

namespace ClashRoyale.Server.Files
{
    internal class CSV
    {
        internal static readonly Dictionary<int, string> Gamefiles = new Dictionary<int, string>();

        internal static Gamefiles Tables;

        internal CSV()
        {
            Gamefiles.Add(1, @"Gamefiles/csv_logic/alliance_badges.csv");
            Gamefiles.Add(2, @"Gamefiles/csv_logic/alliance_roles.csv");
            Gamefiles.Add(3, @"Gamefiles/csv_logic/exp_levels.csv");
            Gamefiles.Add(4, @"Gamefiles/csv_logic/globals.csv");
            Gamefiles.Add(5, @"Gamefiles/csv_logic/resources.csv");
            Gamefiles.Add(6, @"Gamefiles/csv_logic/npcs.csv");
            Gamefiles.Add(7, @"Gamefiles/csv_logic/predefined_decks.csv");
            Gamefiles.Add(8, @"Gamefiles/csv_logic/rarities.csv");
            Gamefiles.Add(9, @"Gamefiles/csv_logic/chest_order.csv");

            Gamefiles.Add(15, @"Gamefiles/csv_logic/locations.csv");

            Gamefiles.Add(19, @"Gamefiles/csv_logic/treasure_chests.csv");

            Gamefiles.Add(26, @"Gamefiles/csv_logic/spells_characters.csv");
            Gamefiles.Add(27, @"Gamefiles/csv_logic/spells_buildings.csv");
            Gamefiles.Add(28, @"Gamefiles/csv_logic/spells_other.csv");

            Gamefiles.Add(55, @"Gamefiles/csv_logic/resource_packs.csv");
            Gamefiles.Add(57, @"Gamefiles/csv_logic/regions.csv");
            Gamefiles.Add(60, @"Gamefiles/csv_logic/achievements.csv");

            Gamefiles.Add(66, @"Gamefiles/csv_logic/shop.csv");

            Tables = new Gamefiles();

            Parallel.ForEach(Gamefiles, File =>
            {
                if (new FileInfo(File.Value).Exists) Tables.Initialize(new Table(File.Value), File.Key);
            });

            Console.WriteLine("Loaded " + Gamefiles.Count + " gamefiles and stored into memory!\n");
        }
    }
}