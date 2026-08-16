using FleetPulse.API.Data;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FleetPulse.API.Repositories.Implementations
{

    public class DriverRepository : IDriverRepository
    {
        private readonly FleetPulseDbContext _context;
        public DriverRepository(FleetPulseDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> CreateDriverAsync(Driver driver)
        {
            try
            {
                var existingDriver = await GetDriverByIdAsync(driver.Id);
                if (existingDriver == null)
                {
                    throw new Exception($"A driver with ID {driver.Id} not found.");
                }

                existingDriver.FirstName = driver.FirstName;
                existingDriver.LastName = driver.LastName;
                existingDriver.Email = driver.Email;
                existingDriver.PasswordHash = driver.PasswordHash;
                existingDriver.StartTime = driver.StartTime;
                existingDriver.EndTime = driver.EndTime;
               
                
                await _context.SaveChangesAsync();
                return driver;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while creating a new driver.", ex);
            }

        }

        public async Task<bool> DeleteDriverAsync(int id)
        {
            try
            {
               var driver = await GetDriverByIdAsync(id);
                if (driver == null)
                {
                    return false; // Driver not found
                }
                _context.Drivers.Remove(driver);
                await _context.SaveChangesAsync();
                return true;
            }
            catch( Exception ex)
            {
                throw new Exception($"An error occurred while deleting the driver with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {

            try
            {
                var drivers = await _context.Drivers.ToListAsync();

                return drivers;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while retrieving drivers.", ex);

            }
        }

        public async Task<Driver> GetDriverByIdAsync(int id)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while retrieving the driver with ID {id}.", ex);
            }
        }

        public async Task<Driver> UpdateDriverAsync(Driver driver)
        {
            try
            {
                _context.Drivers.Update(driver);
                await _context.SaveChangesAsync();
                return driver;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while updating the driver with ID {driver.Id}.", ex);
            }
        }
    }
}
