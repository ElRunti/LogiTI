using FleetPulse.API.Models;

namespace FleetPulse.API.Repositories.Contracts
{
    public interface IDriverRepository
    {
        public Task<IEnumerable<Driver>> GetAllDriversAsync();
        public Task<Driver> GetDriverByIdAsync(int id);
        public Task<Driver> CreateDriverAsync(Driver driver);
        public Task<Driver> UpdateDriverAsync(Driver driver);
        public Task<bool> DeleteDriverAsync(int id);

    }
}
