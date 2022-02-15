using GeoGo.Server.Data;

namespace GeoGo.Server.Features.Profiles.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Validation.User;

    public class UpdateProfileRequestModel
    {
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ProfilePhotoUrl { get; set; }

        [MaxLength(MaxLocationLength)]
        public string Location { get; set; }

        [MaxLength(MaxBioLength)]
        public string Bio { get; set; }
    }
}
