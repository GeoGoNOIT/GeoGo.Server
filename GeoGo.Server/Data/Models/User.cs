namespace GeoGo.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public IEnumerable<Game> Games { get; } = new HashSet<Game>();
    }
}
