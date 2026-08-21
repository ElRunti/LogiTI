using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetPulse.Wearable.Models
{
    public class DeliveryDto
    {
        public int IdDelivery { get; set; }
        public int Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
