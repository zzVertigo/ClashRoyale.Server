using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClashRoyale.Server.Database;
using ClashRoyale.Server.Database.Models;
using Newtonsoft.Json;

namespace ClashRoyale.Server.Logic.Slots
{
    internal class Players : ConcurrentDictionary<long, Player>
    {
        internal long Seed;

        public Players()
        {
            Seed = MySQL.GetSeed("Players", "UserID");
        }

        internal void Add(Player Player)
        {
            if (ContainsKey(Player.UserID))
            {
                if (!TryUpdate(Player.UserID, Player, Player))
                {
                    // Debug.WriteLine("[*] " + this.GetType().Name + " : " + "Unsuccessfuly updated the specified player to the dictionnary.");
                }
            }
            else
            {
                if (!TryAdd(Player.UserID, Player))
                {
                }
            }
        }

        internal void Remove(Player Player)
        {
            Player TmpPlayer;

            if (ContainsKey(Player.UserID))
                if (!TryRemove(Player.UserID, out TmpPlayer))
                {
                }
        }

        internal Player GetPlayer(Device Device, long UserID, bool Store = true)
        {
            if (!ContainsKey(UserID))
            {
                Player Player = null;

                using (var Database = new Context())
                {
                    var Data = Database.Players.Find(UserID);

                    if (Data != null)
                        if (!string.IsNullOrEmpty(Data.Data))
                        {
                            Player = new Player(null, UserID);

                            JsonConvert.PopulateObject(Data.Data, Player);

                            if (Store)
                                Add(Player);
                        }
                }

                return Player;
            }

            return this[UserID];
        }

        internal Player CreatePlayer(Device Device, long UserID = 0, bool Store = true)
        {
            var Player = new Player(Device, Interlocked.Increment(ref Seed));

            var Chars = "0123456789abcdefghijklmnopqrstuvwxyz";

            var RandomToken = Enumerable.Repeat(Chars, 40)
                .Select(s => s[new Random().Next(s.Length)]).ToArray();

            foreach (var Letter in RandomToken) Player.Token += Letter;

            using (var Database = new Context())
            {
                var PlayerModel = new PlayerModel
                {
                    UserID = Player.UserID,
                    Data = JsonConvert.SerializeObject(Player, Formatting.Indented)
                };

                Database.Players.Add(PlayerModel);
                Database.SaveChanges();

                if (Store)
                    Add(Player);
            }

            return Player;
        }

        internal void Save(Player Player)
        {
            using (Context Database = new Context())
            {
                PlayerModel Data = Database.Players.Find(Player.UserID);

                if (Data != null)
                {
                    Data.UserID = Player.UserID;
                    Data.Data = JsonConvert.SerializeObject(Player, Formatting.Indented);
                }

                Database.SaveChangesAsync();
            }
        }

        internal void SaveAll()
        {
            Player[] Players = this.Values.ToArray();

            Parallel.ForEach(Players, Player =>
            {
                try
                {
                    this.Save(Player);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
        }
    }
}