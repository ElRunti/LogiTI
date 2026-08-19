using AutoMapper;
using FleetPulse.API.DTOs.Delivery;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using FleetPulse.API.Services.Contracts;

namespace FleetPulse.API.Services.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public async Task<DeliveryDto> CreateDeliveryAsync(DeliveryCreateDto deliveryCreateDto)
        {
            try
            {
                var deliveryModel = _mapper.Map<Delivery>(deliveryCreateDto);
                var createDelivery = await _deliveryRepository.CreateDeliveryAsync(deliveryModel);
                var deliveryDto = _mapper.Map<DeliveryDto>(createDelivery);
                return deliveryDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the delivery: {ex.Message}", ex);

            }
        }
        

        public async Task<bool> DeleteDeliveryAsync(int deliveryId)
        {
            try
            {
               return await _deliveryRepository.DeleteDeliveryAsync(deliveryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the delivery with ID {deliveryId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<DeliveryDto>> GetAllDeliveriesAsync()
        {
            try
            {
                var deliverys = await _deliveryRepository.GetAllDeliveriesAsync();
                var deliverysDto = _mapper.Map<IEnumerable<DeliveryDto>>(deliverys);
                return deliverysDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving deliverys: {ex.Message}", ex);
            }

        }

        public async Task<DeliveryDto> GetDeliveryByIdAsync(int deliveryId)
        {
            try
            {
                var deliveryModel = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
                if(deliveryModel == null)
                {
                    throw new Exception($"Delivey with ID {deliveryId} not found.");
                }
                var deliveryDto = _mapper.Map<DeliveryDto>(deliveryModel);
                return deliveryDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the delivery with ID {deliveryId}: {ex.Message}", ex);
            }
        }

        public async Task<DeliveryDto> UpdateDeliveryAsync(int deliveryId, DeliveryUpdateDto deliveryUpdateDto)
        {
            try
            {

                var findDelivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
                _mapper.Map(deliveryUpdateDto, findDelivery);
                var updateDelivery = await _deliveryRepository.UpdateDeliveryAsync(findDelivery);
                var deliveryDto = _mapper.Map<DeliveryDto>(updateDelivery);
                return deliveryDto;
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while retrieving the delivery with ID {deliveryId}: {ex.Message}", ex);
            }
        }
    }
}
