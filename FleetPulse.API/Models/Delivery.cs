using FleetPulse.API.Models.Enums;

namespace FleetPulse.API.Models
{
    public class Delivery
    {
        public int IdDelivery { get; set; }
        public int IdPackage { get; set; }
        public int IdDriver { get; set; }
        public int IdCustomer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DeliveryStatus Status { get; set; }

        //Property navegation to the Package entity
        public ICollection<Package> Packages { get; set; }
        //Property navegation to the Driver entity
        public Driver Driver { get; set; }
        //Property navegation to the Customer entity
        public Customer Customer { get; set; }
    }
}
