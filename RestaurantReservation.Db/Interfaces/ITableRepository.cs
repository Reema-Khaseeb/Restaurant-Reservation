using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface ITableRepository
    {
        Task CreateTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableAsync(int tableId);
        Task UpdateTableAsync(Table table);
    }
}