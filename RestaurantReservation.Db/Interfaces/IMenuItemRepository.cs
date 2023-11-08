using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IMenuItemRepository
    {
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemAsync(int menuItemId);
        Task UpdateMenuItemAsync(MenuItem menuItem);
    }
}