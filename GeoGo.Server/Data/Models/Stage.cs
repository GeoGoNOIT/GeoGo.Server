using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Stage : DeletableEntity
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public string RiddleId { get; set; }

        public Riddle Riddle { get; set; }

        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
