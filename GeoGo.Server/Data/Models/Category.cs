namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Category : Entity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; } = new HashSet<Game>();
    }
}
