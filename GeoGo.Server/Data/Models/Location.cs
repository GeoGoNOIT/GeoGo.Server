using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Location : DeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } // Use Google Maps Name

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Stage> Stages { get; set; } = new HashSet<Stage>();
    }
}
