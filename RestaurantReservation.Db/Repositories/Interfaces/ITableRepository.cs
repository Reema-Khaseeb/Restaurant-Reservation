using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface ITableRepository
    {
        Task CreateTableAsync(Table table);
        Task DeleteTableAsync(Table table);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<Table> GetTableAsync(int tableId);
        Task UpdateTableAsync(Table table);
    }
}