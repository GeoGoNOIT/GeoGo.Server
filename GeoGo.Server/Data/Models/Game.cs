using System.ComponentModel.DataAnnotations;
using GeoGo.Server.Data.Models.Base;
using GeoGo.Server.Data.Models.Enums;

namespace GeoGo.Server.Data.Models
{
    using static Validation.Game;

    public class Game : DeletableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public GameType GameType { get; set; }

        [Required]
        public string? CreatorId { get; set; }

        public User Creator { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public bool IsPrivate { get; set; }

        public IEnumerable<Stage> Stages { get; set; } = new HashSet<Stage>();

        public IEnumerable<Feedback> Feedbacks { get; } = new HashSet<Feedback>();
    }
}
