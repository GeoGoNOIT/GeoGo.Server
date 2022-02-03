using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Clue : DeletableEntity
    {
        public string Id { get; set; }

        public string Text { get; set; }

        // public TYPE Media { get; set; }

        public int MinusPoints { get; set; }

        public int RiddleId { get; set; }

        public Riddle Riddle { get; set; }
    }
}
