using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;

namespace RestaurantReservation.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.CreateOrderItemAsync(orderItem);
        }

        public async Task<OrderItem> GetOrderItemAsync(int orderItemId)
        {
            return await _orderItemRepository.GetOrderItemAsync(orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _orderItemRepository.GetAllOrderItemsAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            await _orderItemRepository.UpdateOrderItemAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            await _orderItemRepository.DeleteOrderItemAsync(orderItemId);
        }
    }
}
