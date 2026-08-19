using FleetPulse.API.Models.Enums;

namespace FleetPulse.API.DTOs.Package
{
    public class PackageDto
    {
        public int IdPackage { get; set; }
        public string Address { get; set; }
        public PackageStatus Status { get; set; }
        public DateTime PickupTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public int IdDriver { get; set; }
        public int IdCustomer { get; set; }
    }
}
