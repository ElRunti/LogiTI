using FleetPulse.API.Models;

namespace FleetPulse.API.Repositories.Contracts
{
    public interface IPackageRepository
    {
        public Task<IEnumerable<Package>> GetAllPackagesAsync();
        public Task<Package> GetPackageByIdAsync(int id);
        public Task<Package> CreatePackageAsync(Package package);
        public Task<Package> UpdatePackageAsync(Package package);
        public Task<bool> DeletePackageAsync(int id);
    }
}
