namespace GeoGo.Server.Features.Games.Models
{
    public class GameDetailsServiceModel : GameListingServiceModel
    {
        public string Description { get; set; }
        
        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
