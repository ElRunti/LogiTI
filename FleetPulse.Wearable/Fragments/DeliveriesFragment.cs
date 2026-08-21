using System.Net.Http;
using System.Text.Json;
using Android.Views;
using Android.Widget;
using FleetPulse.Wearable.Models;

namespace FleetPulse.Wearable.Fragments
{
    public class DeliveriesFragment : AndroidX.Fragment.App.Fragment
    {
        private LinearLayout _container;
        private const string BaseUrl = "http://192.168.1.66:5245";

        public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_deliveries, container, false);
            _container = view.FindViewById<LinearLayout>(Resource.Id.deliveriesContainer);
            _ = LoadDeliveries();
            return view;
        }

        private async Task LoadDeliveries()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync($"{BaseUrl}/api/delivery");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryDto>>(response,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                Activity?.RunOnUiThread(() =>
                {
                    _container.RemoveAllViews();

                    var title = new TextView(Activity);
                    title.Text = "Deliveries";
                    title.SetTextColor(Android.Graphics.Color.ParseColor("#888888"));
                    title.TextSize = 9f;
                    title.Gravity = Android.Views.GravityFlags.CenterHorizontal;
                    _container.AddView(title);

                    foreach (var delivery in deliveries)
                    {
                        var row = new LinearLayout(Activity);
                        row.Orientation = Orientation.Horizontal;
                        row.SetPadding(4, 4, 4, 4);

                        bool isDelivered = delivery.Status == 2;
                        row.SetBackgroundColor(Android.Graphics.Color.ParseColor(
                            isDelivered ? "#1a2a1a" : "#2a1a1a"));

                        var icon = new TextView(Activity);
                        icon.Text = isDelivered ? "✓" : "●";
                        icon.SetTextColor(Android.Graphics.Color.ParseColor(
                            isDelivered ? "#4CAF50" : "#F44336"));
                        icon.TextSize = 10f;

                        var address = new TextView(Activity);
                        address.Text = $"Entrega #{delivery.IdDelivery}";
                        address.SetTextColor(Android.Graphics.Color.ParseColor("#666666"));
                        address.TextSize = 9f;

                        row.AddView(icon);
                        row.AddView(address);
                        _container.AddView(row);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}