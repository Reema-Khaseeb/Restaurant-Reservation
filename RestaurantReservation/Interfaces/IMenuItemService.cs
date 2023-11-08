using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Interfaces
{
    public interface IMenuItemService
    {
        Task CreateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int menuItemId);
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemAsync(int menuItemId);
        Task UpdateMenuItemAsync(MenuItem menuItem);
    }
}