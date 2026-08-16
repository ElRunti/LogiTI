using FleetPulse.API.DTOs.Customer;

namespace FleetPulse.API.Services.Contracts
{
    public interface ICustomerService
    {
        public Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto);
        public Task<CustomerDto> UpdateCustomerAsync(int customerId, CustomerUpdateDto customerUpdateDto);
        public Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        public Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        public Task<bool> DeleteCustomerAsync(int customerId);
    }
}
