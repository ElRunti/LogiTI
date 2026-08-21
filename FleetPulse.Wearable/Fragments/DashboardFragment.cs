using Android.Views;
using Android.Widget;
using FleetPulse.Wearable.Models;
using System.Net.Http;
using System.Text.Json;

namespace FleetPulse.Wearable.Fragments
{
    public class DashboardFragment : AndroidX.Fragment.App.Fragment
    {
        private TextView _tvDelivered;
        private TextView _tvPending;
        private ProgressBar _progressDelivery;
        private TextView _tvProgress;

        private const string BaseUrl = "http://192.168.1.66:5245";
        public override void OnResume()
        {
            base.OnResume();
            _ = LoadDashboardStats();
        }

        public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_dashboard, container, false);

            _tvDelivered = view.FindViewById<TextView>(Resource.Id.tvDelivered);
            _tvPending = view.FindViewById<TextView>(Resource.Id.tvPending);
            _progressDelivery = view.FindViewById<ProgressBar>(Resource.Id.progressDelivery);
            _tvProgress = view.FindViewById<TextView>(Resource.Id.tvProgress);

            _ = LoadDashboardStats();

            return view;
        }

        private async Task LoadDashboardStats()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync($"{BaseUrl}/api/delivery");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryDto>>(response,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                int completed = deliveries.Count(d => d.Status == 2);
                int pending = deliveries.Count(d => d.Status == 0);
                int total = deliveries.Count;
                int percentage = total == 0 ? 0 : (completed * 100 / total);

                Activity?.RunOnUiThread(() =>
                {
                    _tvDelivered.Text = completed.ToString();
                    _tvPending.Text = pending.ToString();
                    _progressDelivery.Progress = percentage;
                    _tvProgress.Text = $"{percentage}% completado";
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}