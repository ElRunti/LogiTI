using AndroidX.Fragment.App;
using AndroidX.ViewPager2.Widget;

namespace FleetPulse.Wearable
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var viewPager = FindViewById<ViewPager2>(Resource.Id.viewPager);
            viewPager.Adapter = new WearablePagerAdapter(this);
        }
    }
}
