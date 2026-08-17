using AutoMapper;
using FleetPulse.API.DTOs.Customer;
using FleetPulse.API.Models;
using FleetPulse.API.Repositories.Contracts;
using FleetPulse.API.Services.Contracts;

namespace FleetPulse.API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerCreateDto)
        {
            try
            {
                var customerModel = _mapper.Map<Customer>(customerCreateDto);
                customerModel.PasswordHash = BCrypt.Net.BCrypt.HashPassword(customerCreateDto.Password);
                var createdCustomer = await _customerRepository.CreateCustomerAsync(customerModel);
                var customerDto = _mapper.Map<CustomerDto>(createdCustomer);
                return customerDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the customer: {ex.Message}", ex);

            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            try
            {
                var result = await _customerRepository.DeleteCustomerAsync(customerId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the customer with ID {customerId}: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomersAsync();
                var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                return customerDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving customers: {ex.Message}", ex);
            }
            
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
                if (customer == null)
                {
                    throw new Exception($"Customer with ID {customerId} not found.");
                }
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return customerDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the customer with ID {customerId}: {ex.Message}", ex);
            }
        }

        public async Task<CustomerDto> UpdateCustomerAsync(int customerId, CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                
                var findCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
                _mapper.Map(customerUpdateDto, findCustomer);
                var updateCustomer = await _customerRepository.UpdateCustomerAsync(findCustomer);
                var customerDto = _mapper.Map<CustomerDto>(updateCustomer);
                return customerDto;
            } catch (Exception ex) {

                throw new Exception($"An error occurred while retrieving the customer with ID {customerId}: {ex.Message}", ex);
            }
           
        }

    }
}
