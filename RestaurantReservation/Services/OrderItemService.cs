using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IObjectValidator _objectValidator;

        public OrderItemService(IOrderItemRepository orderItemRepository, IObjectValidator objectValidator)
        {
            _orderItemRepository = orderItemRepository;
            _objectValidator = objectValidator ??
                throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            _objectValidator.ValidateObjectNotNull(orderItem);
            await _orderItemRepository.CreateOrderItemAsync(orderItem);
        }

        public async Task<OrderItem> GetOrderItemAsync(int orderItemId)
        {
            _objectValidator.ValidatePositiveObjectId(orderItemId);
            return await _orderItemRepository.GetOrderItemAsync(orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _orderItemRepository.GetAllOrderItemsAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _objectValidator.ValidateObjectNotNull(orderItem);
            await _orderItemRepository.UpdateOrderItemAsync(orderItem);
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _orderItemRepository.GetOrderItemAsync(orderItemId);

            _objectValidator.ValidateObjectNotNull(orderItem);
            await _orderItemRepository.DeleteOrderItemAsync(orderItemId);
        }
    }
}
