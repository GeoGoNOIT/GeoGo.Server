namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Validation.User;

    public class Profile
    {
        [Key]
        [Required]
        public string UserId { get; set; }

        public string ProfilePhotoUrl { get; set; }

        [MaxLength(MaxLocationLength)]
        public string Location { get; set; }

        [MaxLength(MaxBioLength)]
        public string Bio { get; set; }
    }
}
