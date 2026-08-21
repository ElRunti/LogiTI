using AndroidX.Fragment.App;
using AndroidX.ViewPager2.Adapter;
using FleetPulse.Wearable.Fragments;

namespace FleetPulse.Wearable
{
    public class WearablePagerAdapter : FragmentStateAdapter
    {
        public WearablePagerAdapter(FragmentActivity activity) : base(activity) { }

        public override int ItemCount => 4;

        public override AndroidX.Fragment.App.Fragment CreateFragment(int position)
        {
            return position switch
            {
                0 => new DashboardFragment(),
                1 => new DeliveriesFragment(),
                2 => new RouteFragment(),
                3 => new ConfirmFragment(),
                _ => new DashboardFragment()
            };
        }
    }
}