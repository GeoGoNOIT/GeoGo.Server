namespace GeoGo.Server.Features.Games.Models
{
    public class GameDetailsServiceModel : GameListingServiceModel
    {
        public string Description { get; set; }
        
        public string CreatorId { get; set; }

        public string UserName { get; set; }
    }
}
