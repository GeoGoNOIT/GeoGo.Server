using System.ComponentModel.DataAnnotations;
using GeoGo.Server.Data;

namespace GeoGo.Server.Features.Games
{
    using static Validation.Game;

    public class CreateGameRequestModel
    {
        [Required]
        public string ImageUrl { get; set; }

        public string Title { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
