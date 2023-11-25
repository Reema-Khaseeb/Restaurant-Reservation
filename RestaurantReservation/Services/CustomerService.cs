using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IObjectValidator _objectValidator;

        public CustomerService(ICustomerRepository customerRepository, IObjectValidator objectValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _objectValidator = objectValidator ?? throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            _objectValidator.ValidateObjectNotNull(customer);
            await _customerRepository.CreateCustomerAsync(customer);
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            _objectValidator.ValidatePositiveObjectId(customerId);
            return await _customerRepository.GetCustomerAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _objectValidator.ValidateObjectNotNull(customer);
            await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);

            _objectValidator.ValidateObjectNotNull(customer);
            await _customerRepository.DeleteCustomerAsync(customer);
        }

        public async Task<IEnumerable<Customer>> FindCustomersByReservationPartySizeAsync(int partySizeThreshold)
        {
            if (partySizeThreshold < 0)
            {
                throw new ArgumentException("Invalid party size threshold");
            }

            return await _customerRepository.FindCustomersByReservationPartySizeAsync(partySizeThreshold);
        }
    }
}
