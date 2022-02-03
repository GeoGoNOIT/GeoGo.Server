namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;
    using Enums;

    using static Validation.Riddle;

    public class Riddle : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTextLength)]
        public string Text { get; set; }

        public AnswerType AnswerType { get; set; }

        [MaxLength(MaxAnswerLength)]
        public string CorrectAnswer { get; set; } //TODO

        public int Points { get; set; }

        public IEnumerable<Clue> Clues { get; set; } = new HashSet<Clue>();

        public IEnumerable<Stage> Stages { get; set; } = new HashSet<Stage>();
    }
}
