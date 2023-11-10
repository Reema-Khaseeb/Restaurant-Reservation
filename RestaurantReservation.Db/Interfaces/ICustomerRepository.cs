using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int customerId);
        Task<IEnumerable<Customer>> FindCustomersByReservationPartySizeAsync(int partySizeThreshold);
    }
}
