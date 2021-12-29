using System.ComponentModel.DataAnnotations;
using GeoGo.Server.Data;

namespace GeoGo.Server.Models.Cats
{
    using static Validation.Game;

    public class CreateGameRequestModel
    {
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
