using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task UpdateOrderAsync(Order order);
        Task<double> CalculateAverageOrderAmountAsync(int employeeId);

        Task<List<(Order order, IEnumerable<MenuItem> menuItems)>> ListOrdersAndMenuItemsAsync(int reservationId);
        Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId);
    }
}