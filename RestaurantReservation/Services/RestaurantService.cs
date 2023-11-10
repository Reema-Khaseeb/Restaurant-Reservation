using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Interfaces;

namespace RestaurantReservation.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.CreateRestaurantAsync(restaurant);
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            return await _restaurantRepository.GetRestaurantAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _restaurantRepository.GetAllRestaurantsAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            await _restaurantRepository.DeleteRestaurantAsync(restaurantId);
        }

        public async Task<decimal> CalculateRestaurantTotalRevenueAsync(int restaurantId)
        {
            return await _restaurantRepository.CalculateRestaurantTotalRevenueAsync(restaurantId);
        }

    }
}
