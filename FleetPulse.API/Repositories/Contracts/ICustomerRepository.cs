using FleetPulse.API.Models;

namespace FleetPulse.API.Repositories.Contracts
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(Customer customer);
        public Task<bool> DeleteCustomerAsync(int id);
    }
}
