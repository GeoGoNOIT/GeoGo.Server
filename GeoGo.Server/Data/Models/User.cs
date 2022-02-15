namespace GeoGo.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Base;

    public class User : IdentityUser, IEntity
    {

        public Profile Profile { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public IEnumerable<Game> CreatedGames { get; } = new HashSet<Game>();

        public IEnumerable<Feedback> Feedbacks { get; } = new HashSet<Feedback>();
    }
}
