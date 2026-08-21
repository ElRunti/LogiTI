using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;

namespace FleetPulse.Wearable.Fragments
{
    public class DeliveriesFragment : AndroidX.Fragment.App.Fragment
    {
        public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_deliveries, container, false);
        }
    }
}