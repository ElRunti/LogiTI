using FleetPulse.API.DTOs.Delivery;

namespace FleetPulse.API.Services.Contracts
{
    public interface IDeliveryService
    {
        public Task<DeliveryDto> CreateDeliveryAsync(DeliveryCreateDto deliveryCreateDto);
        public Task<DeliveryDto> UpdateDeliveryAsync(int deliveryId, DeliveryUpdateDto deliveryUpdateDto);
        public Task<DeliveryDto> GetDeliveryByIdAsync(int deliveryId);
        public Task<IEnumerable<DeliveryDto>> GetAllDeliveriesAsync();
        public Task<bool> DeleteDeliveryAsync(int deliveryId);
    }
}
