using System.ComponentModel.DataAnnotations;

namespace ClashRoyale.Server.Database.Models
{
    internal class PlayerModel
    {
        [Key] public long UserID { get; set; }

        public string Data { get; set; }
    }
}