using System.Net.Http;
using System.Text;
using System.Text.Json;
using Android.Views;
using Android.Widget;
using FleetPulse.Wearable.Models;

namespace FleetPulse.Wearable.Fragments
{
    public class ConfirmFragment : AndroidX.Fragment.App.Fragment
    {
        private TextView _tvPackageTracking;
        private Button _btnConfirm;
        private int _pendingDeliveryId;
        private const string BaseUrl = "http://192.168.1.66:5245";

        public override void OnResume()
        {
            base.OnResume();
            _ = LoadPendingDelivery();
        }

        public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_confirm, container, false);
            _tvPackageTracking = view.FindViewById<TextView>(Resource.Id.tvPackageTracking);
            _btnConfirm = view.FindViewById<Button>(Resource.Id.btnConfirmDelivery);
            _btnConfirm.Click += OnConfirmClicked;
            _ = LoadPendingDelivery();
            return view;
        }

        private async Task LoadPendingDelivery()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync($"{BaseUrl}/api/delivery");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryDto>>(response,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var pending = deliveries?.FirstOrDefault(d => d.Status == 0);

                Activity?.RunOnUiThread(() =>
                {
                    if (pending != null)
                    {
                        _pendingDeliveryId = pending.IdDelivery;
                        _tvPackageTracking.Text = $"Entrega #{pending.IdDelivery}";
                    }
                    else
                    {
                        _tvPackageTracking.Text = "Sin entregas pendientes";
                        _btnConfirm.Enabled = false;
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            try
            {
                using var client = new HttpClient();
                var body = new { Status = 2 };
                var json = JsonSerializer.Serialize(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"{BaseUrl}/api/delivery/{_pendingDeliveryId}", content);

                Activity?.RunOnUiThread(() =>
                {
                    _tvPackageTracking.Text = response.IsSuccessStatusCode
                        ? "✓ Entrega confirmada"
                        : "Error al confirmar";
                    _btnConfirm.Enabled = false;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }
    }
}