using FleetPulse.API.Models.Enums;

namespace FleetPulse.API.DTOs.Delivery
{
    public class DeliveryUpdateDto
    {
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
