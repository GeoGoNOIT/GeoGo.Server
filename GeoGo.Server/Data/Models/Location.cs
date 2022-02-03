namespace GeoGo.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Base;

    using static Validation.Location;

    public class Location : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } // Use Google Maps Name

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Stage> Stages { get; set; } = new HashSet<Stage>();
    }
}
