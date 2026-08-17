using FleetPulse.API.DTOs.Customer;
using FleetPulse.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace FleetPulse.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customerFind = await _customerService.GetCustomerByIdAsync(id);
            if (customerFind == null) return BadRequest();
            return Ok(customerFind);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            var createCustomer = await _customerService.CreateCustomerAsync(customerCreateDto);
            if (createCustomer == null) return BadRequest();
            return Created($"api/customer/{createCustomer}", createCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateDto customerUpdateDto, [FromRoute] int id)
        {
            var updateCustomer = await _customerService.UpdateCustomerAsync(id, customerUpdateDto);
            if (updateCustomer == null)  return BadRequest(); 
            return Ok(updateCustomer);
        }

        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var deleteCustomer = await _customerService.DeleteCustomerAsync(id);
            if (!deleteCustomer) return BadRequest();
            return Ok(deleteCustomer);
        }


    }
}
