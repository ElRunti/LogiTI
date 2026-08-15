using FleetPulse.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FleetPulse.API.Models
{
    public class Package
    {
        [Key]
        public int IdPackage { get; set; }
        public string Address { get; set; }
        public PackageStatus Status { get; set; }
        public DateTime PickupTime { get; set; }
        public DateTime DeliveryTime { get; set; }

       // Property navegation to the Driver entity
       public int IdDriver { get; set; }
       public Driver Driver { get; set; }

    }
}
