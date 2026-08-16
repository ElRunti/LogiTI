using FleetPulse.API.Models.Enums;

namespace FleetPulse.API.DTOs.Delivery
{
    public class DeliveryCreateDto
    {
        public int IdPackage { get; set; }
        public int IdDriver { get; set; }
        public int IdCustomer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
