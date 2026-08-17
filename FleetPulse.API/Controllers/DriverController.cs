using FleetPulse.API.DTOs.Driver;
using FleetPulse.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FleetPulse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
       private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var driver = await _driverService.GetAllDriversAsync();
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById([FromRoute] int id)
        {
            var findDriver = await _driverService.GetDriverByIdAsync(id);
            if (findDriver == null) return NotFound();
            return Ok(findDriver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] DriverCreateDto driverCreateDto)
        {
            var driverCreate = await _driverService.CreateDriverAsync(driverCreateDto);
            if (driverCreate == null) return BadRequest();
            return Created($"api/driver/{driverCreate.Id}", driverCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver([FromBody] DriverUpdateDto driverUpdateDto,[FromRoute] int id)
        {
            var driverUpdate = await _driverService.UpdateDriverAsync(id, driverUpdateDto);
            if (driverUpdate == null) return BadRequest();
            return Ok(driverUpdate);

        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] int id){
            var driverDelete = await _driverService.DeleteDriverAsync(id);
            if(driverDelete == null) return NotFound();
            return Ok(driverDelete);
        }


    }
}
