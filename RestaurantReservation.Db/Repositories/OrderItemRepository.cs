using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderItemAsync(OrderItem orderItem)
        {
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderItem> GetOrderItemAsync(int orderItemId)
        {
            return await _context.OrderItems.FindAsync(orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
