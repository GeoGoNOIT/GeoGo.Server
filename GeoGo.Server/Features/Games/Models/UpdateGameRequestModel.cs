namespace GeoGo.Server.Features.Games.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Validation.Game;

    public class UpdateGameRequestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
