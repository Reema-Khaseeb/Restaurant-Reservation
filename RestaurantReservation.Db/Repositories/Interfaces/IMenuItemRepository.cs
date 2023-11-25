using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface IMenuItemRepository
    {
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(MenuItem menuItem);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemAsync(int menuItemId);
        Task UpdateMenuItemAsync(MenuItem menuItem);
    }
}