using FleetPulse.API.Data;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace FleetPulse.API.Repositories.Implementations
{
    public class PackageRepository : IPackageRepository
    {

        private readonly FleetPulseDbContext _context;
        public PackageRepository(FleetPulseDbContext context)
        {
            _context = context;
        }

        public async Task<Package> CreatePackageAsync(Package package)
        {
            try
            {
                await _context.Packages.AddAsync(package);
                await _context.SaveChangesAsync();
                return package;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the package", ex);
            }
        }

        public async Task<bool> DeletePackageAsync(int id)
        {
            try
            {
                var package = await GetPackageByIdAsync(id);
                if (package == null)
                {
                    return false; // Package not found
                }
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the package with ID {id}", ex);
            }
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            try
            {
                return await _context.Packages.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all packages", ex);
            }
        }

        public async Task<Package> GetPackageByIdAsync(int id)
        {
            try
            {
                return await _context.Packages.FirstOrDefaultAsync(p => p.IdPackage == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the package with ID {id}", ex);
            }
        }

        public async Task<Package> UpdatePackageAsync(Package package)
        {
            try
            {
                var  updatedPackage = await GetPackageByIdAsync(package.IdPackage);
                if (updatedPackage == null)
                {
                    throw new Exception($"Package with ID {package.IdPackage} not found");
                }
                updatedPackage.Address = package.Address;
                updatedPackage.Status = package.Status;
                updatedPackage.PickupTime = package.PickupTime;
                updatedPackage.DeliveryTime = package.DeliveryTime;
                
                await _context.SaveChangesAsync();
                return updatedPackage;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the package with ID {package.IdPackage}", ex);
            }
        }
    }
}
