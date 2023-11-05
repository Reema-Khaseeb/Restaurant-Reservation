using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IOrderItemRepository
    {
        Task CreateOrderItemAsync(OrderItem orderItem);
        Task DeleteOrderItemAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemAsync(int orderItemId);
        Task UpdateOrderItemAsync(OrderItem orderItem);
    }
}