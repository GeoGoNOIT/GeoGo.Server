using GeoGo.Server.Data.Models.Base;
using GeoGo.Server.Data.Models.Enums;

namespace GeoGo.Server.Data.Models
{
    public class Riddle : DeletableEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public AnswerType AnswerType { get; set; }

        public string CorrectAnswer { get; set; } //TODO

        public int Points { get; set; }

        public IEnumerable<Clue> Clues { get; set; } = new HashSet<Clue>();

        public IEnumerable<Stage> Stages { get; set; } = new HashSet<Stage>();
    }
}
