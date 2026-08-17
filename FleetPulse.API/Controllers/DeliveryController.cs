using FleetPulse.API.DTOs.Delivery;
using FleetPulse.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FleetPulse.API.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliverys()
        {
            var deliverys = await _deliveryService.GetAllDeliveriesAsync();
            return Ok(deliverys);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetDeliveryById([FromRoute] int id)
        {
            var findDelivery = await  _deliveryService.GetDeliveryByIdAsync(id);
            if (findDelivery == null) return NotFound();
            return Ok(findDelivery);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDelivery([FromBody] DeliveryCreateDto deliveryCreateDto)
        {
            var createDelivery = await _deliveryService.CreateDeliveryAsync(deliveryCreateDto);
            if (createDelivery == null) return BadRequest();
            return Ok(createDelivery);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateDelivery([FromBody] DeliveryUpdateDto deliveryUpdateDto, [FromRoute] int id)
        {
            var updateDelivery = await _deliveryService.UpdateDeliveryAsync(id, deliveryUpdateDto);
            if (updateDelivery == null) return BadRequest();
            return Ok(updateDelivery);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteDelivery([FromRoute] int id)
        {
            var deleteDelivery = await _deliveryService.DeleteDeliveryAsync(id);
            if(!deleteDelivery) return NotFound();
            return NoContent();
        }
    }
}
