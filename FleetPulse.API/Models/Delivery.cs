using FleetPulse.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetPulse.API.Models
{
    public class Delivery
    {
        [Key]
        public int IdDelivery { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DeliveryStatus Status { get; set; }
        //Prperty navigation to Driver entity

        [ForeignKey("Driver")]
        public int IdDriver { get; set; }
        public Driver Driver { get; set; }
        //Property navigation to Customer entity

        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }
        //Property navigation to Packages entity

        [ForeignKey("Packages")]
        public int IdPackage { get; set; }
        public Package Packages { get; set; }
    }
}
