using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;

namespace RestaurantReservation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _orderRepository.GetOrderAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _orderRepository.CalculateAverageOrderAmountAsync(employeeId);
        }

        public async Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrdersAndMenuItemsAsync(reservationId);
        }

        public async Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _orderRepository.ListOrderedMenuItemsAsync(reservationId);
        }
    }
}
