using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
        Task<IEnumerable<Customer>> FindCustomersByReservationPartySizeAsync(int partySizeThreshold);
    }
}
