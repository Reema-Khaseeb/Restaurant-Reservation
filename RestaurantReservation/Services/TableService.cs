using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;

namespace RestaurantReservation.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task CreateTableAsync(Table table)
        {
            await _tableRepository.CreateTableAsync(table);
        }

        public async Task<Table> GetTableAsync(int tableId)
        {
            return await _tableRepository.GetTableAsync(tableId);
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllTablesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            await _tableRepository.UpdateTableAsync(table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepository.DeleteTableAsync(tableId);
        }
    }
}
