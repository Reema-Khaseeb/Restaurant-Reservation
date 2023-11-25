using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> GetCustomerAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> FindCustomersByReservationPartySizeAsync(int partySizeThreshold);
    }
}
