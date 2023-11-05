using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Services
{
    public class TableService
    {
        private readonly RestaurantReservationDbContext _context;

        public TableService(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateTableAsync(Table table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task<Table> GetTableAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }
    }
}
