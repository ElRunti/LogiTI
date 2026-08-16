using FleetPulse.API.Data;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FleetPulse.API.Repositories.Implementations
{
    public class DeliveryRepository : IDeliveryRepository {
        private readonly FleetPulseDbContext _context;
        public DeliveryRepository(FleetPulseDbContext context) {
            _context = context;
        }

        public async Task<Delivery> CreateDeliveryAsync(Delivery delivery)
        {
            try
            {
                await _context.Deliveries.AddAsync(delivery);
                await _context.SaveChangesAsync();
                return delivery;
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while creating the delivery.", ex);
            }
            
        }

        public async Task<bool> DeleteDeliveryAsync(int id)
        {
            try
            {
                var delivery = await GetDeliveryByIdAsync(id);
                if (delivery == null)
                {
                    return false; // Delivery not found
                }
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync();
                return true; // Delivery found and deleted
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while deleting the delivery with ID {id}.", ex);
            }
          
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveriesAsync()
        {
            try
            {
                return await _context.Deliveries.ToListAsync();
            }
            catch(Exception ex) {
                
                throw new Exception("An error occurred while retrieving deliveries.", ex);
            }

        }

        public async Task<Delivery> GetDeliveryByIdAsync(int id)
        {
            try
            {
                return await _context.Deliveries.FindAsync(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the delivery with ID {id}.", ex);
            }
           
        }

        public async Task<Delivery> UpdateDeliveryAsync(Delivery delivery)
        {
            try
            {
                var existingDelivery = await _context.Deliveries.FindAsync(delivery.IdDelivery);
                if (existingDelivery == null)
                {
                    throw new Exception($"Delivery with ID {delivery.IdDelivery} not found.");
                }
                existingDelivery.DeliveryDate = delivery.DeliveryDate;
                existingDelivery.DeliveryTime = delivery.DeliveryTime;
                existingDelivery.Latitude = delivery.Latitude;
                existingDelivery.Longitude = delivery.Longitude;
                existingDelivery.Status = delivery.Status;
                await _context.SaveChangesAsync();
                return delivery;
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while updating the delivery with ID {delivery.IdDelivery}.", ex);
            }
        }
    }
}
