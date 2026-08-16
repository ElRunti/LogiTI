using FleetPulse.API.Data;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FleetPulse.API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FleetPulseDbContext _context;
        public CustomerRepository(FleetPulseDbContext context) { 
        _context = context;

        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the customer: {ex.Message}", ex);

            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return false; // Customer not found
                }
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw new Exception($"An error occurred while deleting the customer with ID {id}: {ex.Message}", ex);
            }


        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _context.Customers.ToListAsync();
                return customers;

            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while retrieving customers: {ex.Message}", ex);
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _context.Customers.FindAsync(id);


            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the customer with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var existingCustomer = await GetCustomerByIdAsync(customer.IdCustomer);
                if (existingCustomer == null)
                {
                    throw new Exception($"Customer with ID {customer.IdCustomer} not found.");
                }
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.City = customer.City;
                existingCustomer.State = customer.State;
                existingCustomer.ZipCode = customer.ZipCode;
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the customer with ID {customer.IdCustomer}: {ex.Message}", ex);

            }
        }
    }
}
