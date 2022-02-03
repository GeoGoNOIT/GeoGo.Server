using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Category : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; } = new HashSet<Game>();
    }
}
