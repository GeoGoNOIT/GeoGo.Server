namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    using static Validation.Clue;

    public class Clue : DeletableEntity
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxTextLength)]
        public string Text { get; set; }

        // public TYPE Media { get; set; }

        public int MinusPoints { get; set; }

        [Required]
        public int RiddleId { get; set; }

        public Riddle Riddle { get; set; }
    }
}
