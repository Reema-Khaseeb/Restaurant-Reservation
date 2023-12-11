using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IObjectValidator _objectValidator;

        public MenuItemService(IMenuItemRepository menuItemRepository, IObjectValidator objectValidator)
        {
            _menuItemRepository = menuItemRepository;
            _objectValidator = objectValidator ??
                throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            _objectValidator.ValidateObjectNotNull(menuItem);
            await _menuItemRepository.CreateMenuItemAsync(menuItem);
        }

        public async Task<MenuItem> GetMenuItemAsync(int menuItemId)
        {
            _objectValidator.ValidatePositiveObjectId(menuItemId);
            return await _menuItemRepository.GetMenuItemAsync(menuItemId);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _menuItemRepository.GetAllMenuItemsAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _objectValidator.ValidateObjectNotNull(menuItem);
            await _menuItemRepository.UpdateMenuItemAsync(menuItem);
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await _menuItemRepository.GetMenuItemAsync(menuItemId);

            _objectValidator.ValidateObjectNotNull(menuItem);
            await _menuItemRepository.DeleteMenuItemAsync(menuItem);
        }
    }
}
