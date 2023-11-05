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
    }
}