using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task UpdateOrderAsync(Order order);
        Task<double> CalculateAverageOrderAmountAsync(int employeeId);
        Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId);
        Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    }
}
