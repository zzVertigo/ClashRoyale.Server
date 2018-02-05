using System.ComponentModel.DataAnnotations;

namespace ClashRoyale.Server.Database.Models
{
    internal class ReplayModel
    {
        [Key] public long ReplayID { get; set; }

        public int ViewCount { get; set; }

        public int Arena { get; set; }

        public string Data { get; set; }
    }
}