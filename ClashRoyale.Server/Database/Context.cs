using ClashRoyale.Server.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyale.Server.Database
{
    internal class Context : DbContext
    {
        internal DbSet<PlayerModel> Players { get; set; }

        internal DbSet<ReplayModel> Replays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder
                .UseMySql(
                    $"Server={MySQL.Hostname};database={MySQL.Database};uid={MySQL.Username};pwd={MySQL.Password};");
        }
    }
}