using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task CreateOrderItemAsync(OrderItem orderItem);
        Task DeleteOrderItemAsync(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task<OrderItem> GetOrderItemAsync(int orderItemId);
        Task UpdateOrderItemAsync(OrderItem orderItem);
    }
}