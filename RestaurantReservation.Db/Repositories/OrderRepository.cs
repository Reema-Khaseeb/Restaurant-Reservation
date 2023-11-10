using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            if (order != null)
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(order));
            }
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            if (order != null)
            {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(order));
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .AverageAsync(o => o.TotalAmount) ?? 0;
        }

        public async Task<IEnumerable<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Where(o => o.ReservationId == reservationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Where(order => order.ReservationId == reservationId)
                .SelectMany(order => order.OrderItems)
                .Select(orderItem => orderItem.MenuItem)
                .OrderBy(menuItem => menuItem.ItemId)
                .ToListAsync();
        }
    }
}
