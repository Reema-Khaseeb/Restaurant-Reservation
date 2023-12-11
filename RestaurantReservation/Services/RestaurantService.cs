using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IObjectValidator _objectValidator;

        public RestaurantService(IRestaurantRepository restaurantRepository, IObjectValidator objectValidator)
        {
            _restaurantRepository = restaurantRepository;
            _objectValidator = objectValidator ??
                throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            _objectValidator.ValidateObjectNotNull(restaurant);
            await _restaurantRepository.CreateRestaurantAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            _objectValidator.ValidatePositiveObjectId(restaurantId);
            return await _restaurantRepository.GetRestaurantAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllRestaurantsAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            _objectValidator.ValidateObjectNotNull(restaurant);
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _restaurantRepository.GetRestaurantAsync(restaurantId);

            _objectValidator.ValidateObjectNotNull(restaurant);
            await _restaurantRepository.DeleteRestaurantAsync(restaurant);
        }

        public async Task<decimal> CalculateRestaurantTotalRevenueAsync(int restaurantId)
        {
            return await _restaurantRepository.CalculateRestaurantTotalRevenueAsync(restaurantId);
        }

    }
}
