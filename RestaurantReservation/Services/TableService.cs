using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IObjectValidator _objectValidator;

        public TableService(ITableRepository tableRepository, IObjectValidator objectValidator)
        {
            _tableRepository = tableRepository ?? throw new ArgumentNullException(nameof(tableRepository));
            _objectValidator = objectValidator ?? throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateTableAsync(Table table)
        {
            _objectValidator.ValidateObjectNotNull(table);
            await _tableRepository.CreateTableAsync(table);
        }

        public async Task<Table> GetTableAsync(int tableId)
        {
            _objectValidator.ValidatePositiveObjectId(tableId);
            return await _tableRepository.GetTableAsync(tableId);
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _tableRepository.GetAllTablesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            _objectValidator.ValidateObjectNotNull(table);
            await _tableRepository.UpdateTableAsync(table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _tableRepository.GetTableAsync(tableId);

            _objectValidator.ValidateObjectNotNull(table);
            await _tableRepository.DeleteTableAsync(table);
        }
    }
}
