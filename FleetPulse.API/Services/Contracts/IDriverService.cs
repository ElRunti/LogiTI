using FleetPulse.API.DTOs.Driver;

namespace FleetPulse.API.Services.Contracts
{
    public interface IDriverService
    {
        public Task<DriverDto> CreateDriverAsync(DriverCreateDto driverCreateDto);
        public Task<DriverDto> UpdateDriverAsync(int driverId, DriverUpdateDto driverUpdateDto);
        public Task<DriverDto> GetDriverByIdAsync(int driverId);
        public Task<IEnumerable<DriverDto>> GetAllDriversAsync();
        public Task<bool> DeleteDriverAsync(int driverId);


    }
}
