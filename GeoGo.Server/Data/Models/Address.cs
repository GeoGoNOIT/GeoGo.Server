namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    public class Address : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Coordinates { get; set; }

        // QR code

        public IEnumerable<Location> Locations { get; set; } = new HashSet<Location>();
    }
}
