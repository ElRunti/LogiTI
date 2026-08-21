using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetPulse.Wearable.Models
{
    public class DashboardStats
    {
        public int CompletedDeliveries { get; set; }
        public int PendingDeliveries { get; set; }
        public int TotalDeliveries { get; set; }
        public double CompletionPercentage =>
            TotalDeliveries == 0 ? 0 : (CompletedDeliveries * 100.0 / TotalDeliveries);
    }
}
