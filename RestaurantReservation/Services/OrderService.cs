using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IObjectValidator _objectValidator;

        public OrderService(IOrderRepository orderRepository, IObjectValidator objectValidator)
        {
            _orderRepository = orderRepository;
            _objectValidator = objectValidator ??
                throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateOrderAsync(Order order)
        {
            _objectValidator.ValidateObjectNotNull(order);
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            _objectValidator.ValidatePositiveObjectId(orderId);
            return await _orderRepository.GetOrderAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _objectValidator.ValidateObjectNotNull(order);
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderAsync(orderId);

            _objectValidator.ValidateObjectNotNull(order);
            await _orderRepository.DeleteOrderAsync(order);
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _orderRepository.CalculateAverageOrderAmountAsync(employeeId);
        }

        public async Task<List<(Order order, IEnumerable<MenuItem> menuItems)>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
        }

        public async Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrderedMenuItemsAsync(reservationId);
        }
    }
}
