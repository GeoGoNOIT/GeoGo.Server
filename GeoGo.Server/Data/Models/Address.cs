using GeoGo.Server.Data.Models.Base;

namespace GeoGo.Server.Data.Models
{
    public class Address : DeletableEntity
    {
        public int Id { get; set; }

        public string Coordinates { get; set; }

        // QR code

        public IEnumerable<Location> Locations { get; set; } = new HashSet<Location>();
    }
}
