using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;

namespace RestaurantReservation.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }

            await _menuItemRepository.CreateMenuItemAsync(menuItem);
        }

        public async Task<MenuItem> GetMenuItemAsync(int menuItemId)
        {
            return await _menuItemRepository.GetMenuItemAsync(menuItemId);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllMenuItemsAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(nameof(menuItem));
            }

            await _menuItemRepository.UpdateMenuItemAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            await _menuItemRepository.DeleteMenuItemAsync(menuItemId);
        }
    }
}
