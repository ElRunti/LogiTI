using FleetPulse.API.Models.Enums;

namespace FleetPulse.API.DTOs.Package
{
    public class PackageUpdate
    {
        public string Address { get; set; }
        public PackageStatus Status { get; set; }
        public DateTime PickupTime { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
