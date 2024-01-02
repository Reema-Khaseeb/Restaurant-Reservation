using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.Interfaces;

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
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
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
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
        {
            return await _context.Orders
                .Where(o => o.EmployeeId == employeeId)
                .AverageAsync(o => o.TotalAmount) ?? 0;
        }

        public async Task<List<(Order order, IEnumerable<MenuItem> menuItems)>> ListOrdersAndMenuItemsAsync(int reservationId)
        {
            var ordersAndMenuItems = await _context.Orders
                .Where(o => o.ReservationId == reservationId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();

            return ordersAndMenuItems
                .Select(o => (o, o.OrderItems.Select(oi => oi.MenuItem).Distinct()))
                .ToList();
        }

        public async Task<IEnumerable<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
        {
            return await _context.Orders
                .Where(order => order.ReservationId == reservationId)
                .SelectMany(order => order.OrderItems
                    .Select(orderItem => orderItem.MenuItem))
                .Distinct()
                .OrderBy(menuItem => menuItem.ItemId)
                .ToListAsync();
        }
    }
}
