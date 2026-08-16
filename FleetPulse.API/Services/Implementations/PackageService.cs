using AutoMapper;
using FleetPulse.API.DTOs.Package;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using FleetPulse.API.Services.Contracts;

namespace FleetPulse.API.Services.Implementations
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;

        public PackageService(IPackageRepository packageRepository, IMapper mapper)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<PackageDto> CreatePackageAsync(PackageCreateDto packageCreateDto)
        {
            try
            {
                var packageModel = _mapper.Map<Package>(packageCreateDto);
                var createdPackage = await _packageRepository.CreatePackageAsync(packageModel);
                var packageDto = _mapper.Map<PackageDto>(createdPackage);
                return packageDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the package: {ex.Message}", ex);
            }
        }


        public async Task<bool> DeletePackageAsync(int packageId)
        {
            try
            {
                return await _packageRepository.DeletePackageAsync(packageId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the package with ID {packageId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<PackageDto>> GetAllPackagesAsync()
        {
            try
            {
                var packages = await _packageRepository.GetAllPackagesAsync();
                var packagesDto = _mapper.Map<IEnumerable<PackageDto>>(packages);
                return packagesDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving packages: {ex.Message}", ex);
            }
        }

        public async Task<PackageDto> GetPackageByIdAsync(int packageId)
        {
            try
            {
                var packageModel = await _packageRepository.GetPackageByIdAsync(packageId);
                if (packageModel == null)
                {
                    throw new Exception($"Package with ID {packageId} not found.");
                }
                var packageDto = _mapper.Map<PackageDto>(packageModel);
                return packageDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the package with ID {packageId}: {ex.Message}", ex);
            }
        }

        public async Task<PackageDto> UpdatePackageAsync(int packageId, PackageUpdateDto packageUpdateDto)
        {
            try
            {
                var findPackage = await _packageRepository.GetPackageByIdAsync(packageId);
                if (findPackage == null)
                {
                    throw new Exception($"Package with ID {packageId} not found to update.");
                }

                _mapper.Map(packageUpdateDto, findPackage);
                var updatedPackage = await _packageRepository.UpdatePackageAsync(findPackage);
                var packageDto = _mapper.Map<PackageDto>(updatedPackage);
                return packageDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the package with ID {packageId}: {ex.Message}", ex);
            }
        }
    }
}
