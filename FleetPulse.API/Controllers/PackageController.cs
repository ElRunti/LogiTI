using FleetPulse.API.DTOs.Package;
using FleetPulse.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FleetPulse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPackages()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById([FromRoute] int id)
        {
            var findPackage = await _packageService.GetPackageByIdAsync(id);
            if(findPackage == null) return NotFound();
            return Ok(findPackage);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] PackageCreateDto packageCreateDto)
        {
            var createPackage = await _packageService.CreatePackageAsync(packageCreateDto);
            if(createPackage == null) return BadRequest();
            return Created($"api/delivery/{createPackage.IdPackage}",createPackage);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage([FromBody] PackageUpdateDto packageUpdateDto, [FromRoute] int id)
        {
            var updatePackage = await _packageService.UpdatePackageAsync(id, packageUpdateDto);
            if(updatePackage == null) return NotFound();
            return Ok(updatePackage);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage([FromRoute] int id)
        {
            var deletePackage = await _packageService.DeletePackageAsync(id);
            if(!deletePackage) return NotFound();
            return NoContent();
        }
    }
}
