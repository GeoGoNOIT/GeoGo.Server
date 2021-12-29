using System.ComponentModel.DataAnnotations;

namespace GeoGo.Server.Data.Models
{
    using static Validation.Game;

    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
