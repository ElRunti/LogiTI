using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Android.Views;
using Android.Views;
using Android.Widget;
using FleetPulse.Wearable.Models;

namespace FleetPulse.Wearable.Fragments
{
    public class RouteFragment : AndroidX.Fragment.App.Fragment
    {
        private TextView _tvCustomerName;
        private TextView _tvAddress;
        private const string BaseUrl = "http://192.168.1.66:5245";

        public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_route, container, false);
            _tvCustomerName = view.FindViewById<TextView>(Resource.Id.tvCustomerName);
            _tvAddress = view.FindViewById<TextView>(Resource.Id.tvAddress);
            _ = LoadNextRoute();
            return view;
        }

        private async Task LoadNextRoute()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync($"{BaseUrl}/api/delivery");
                var deliveries = JsonSerializer.Deserialize<List<DeliveryDto>>(response,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var next = deliveries?.FirstOrDefault(d => d.Status == 0);

                Activity?.RunOnUiThread(() =>
                {
                    if (next != null)
                    {
                        _tvCustomerName.Text = $"Entrega #{next.IdDelivery}";
                        _tvAddress.Text = $"Lat: {next.Latitude}, Lng: {next.Longitude}";
                    }
                    else
                    {
                        _tvCustomerName.Text = "Sin entregas pendientes";
                        _tvAddress.Text = "";
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