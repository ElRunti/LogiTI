using FleetPulse.API.DTOs.Package;

namespace FleetPulse.API.Services.Contracts
{
    public interface IPackageService
    {
        public Task<PackageDto> CreatePackageAsync(PackageCreateDto packageCreateDto);
        public Task<PackageDto> UpdatePackageAsync(int packageId, PackageUpdateDto packageUpdateDto);
        public Task<PackageDto> GetPackageByIdAsync(int packageId);
        public Task<IEnumerable<PackageDto>> GetAllPackagesAsync();
        public Task<bool> DeletePackageAsync(int packageId);
    }
}
