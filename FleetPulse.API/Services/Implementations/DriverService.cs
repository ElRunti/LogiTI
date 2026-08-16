using AutoMapper;
using FleetPulse.API.DTOs.Driver;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using FleetPulse.API.Repositories.Implementations;
using FleetPulse.API.Services.Contracts;

namespace FleetPulse.API.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;
        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverDto> CreateDriverAsync(DriverCreateDto driverCreateDto)
        {
            try
            {
                var driverModel = _mapper.Map<Driver>(driverCreateDto);
                var driverCreate = await _driverRepository.CreateDriverAsync(driverModel);
                var driverDto = _mapper.Map<DriverDto>(driverCreate);
                return driverDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the driver: {ex.Message}", ex);
            }
            
        }

        public async Task<bool> DeleteDriverAsync(int driverId)
        {
            try
            {
                var result = await _driverRepository.DeleteDriverAsync(driverId);
                return result;

            } catch (Exception ex) {
                throw new Exception($"An error occurred while deleting the driver with ID {driverId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<DriverDto>> GetAllDriversAsync()
        {
            try
            {
                var drivers = await _driverRepository.GetAllDriversAsync();
                var driversDto = _mapper.Map<IEnumerable<DriverDto>>(drivers);
                return driversDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving drivers: {ex.Message}", ex);
            }
        }

        public async Task<DriverDto> GetDriverByIdAsync(int driverId)
        {
            try
            {
                var driver = await _driverRepository.GetDriverByIdAsync(driverId);
                if (driver == null)
                {
                    throw new Exception($"Driver with ID { driverId } not found");
                }

                var driverDto = _mapper.Map<DriverDto>(driver);
                return driverDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the driver with ID {driverId}: {ex.Message}", ex);
            }
           
        }

        public async Task<DriverDto> UpdateDriverAsync(int driverId, DriverUpdateDto driverUpdateDto)
        {
            try
            {
                
                var findDriver = await _driverRepository.GetDriverByIdAsync(driverId);
                _mapper.Map(driverUpdateDto, findDriver);
                var updateDriver = await _driverRepository.UpdateDriverAsync(findDriver);
                var driverDto = _mapper.Map<DriverDto>(updateDriver);
                return driverDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the driver with ID {driverId}: {ex.Message}", ex);
            }
        }
    }
}
