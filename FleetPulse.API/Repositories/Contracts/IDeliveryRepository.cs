using FleetPulse.API.Models;

namespace FleetPulse.API.Repositories.Contracts
{
    public interface IDeliveryRepository
    {
        public Task<IEnumerable<Delivery>> GetAllDeliveriesAsync();
        public Task<Delivery> GetDeliveryByIdAsync(int id);
        public Task<Delivery> CreateDeliveryAsync(Delivery delivery);
        public Task<Delivery> UpdateDeliveryAsync(Delivery delivery);
        public Task<bool> DeleteDeliveryAsync(int id);
    }
}
