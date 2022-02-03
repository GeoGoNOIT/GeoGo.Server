namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Stage : DeletableEntity
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int RiddleId { get; set; }

        public Riddle Riddle { get; set; }

        [Required]
        public int GameId { get; set; }

        public Game Game { get; set; }
    }
}
