using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Feedback : DeletableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }

        // Media
    }
}
