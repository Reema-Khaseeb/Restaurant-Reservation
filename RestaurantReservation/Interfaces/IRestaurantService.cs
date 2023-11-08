using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Interfaces
{
    public interface IRestaurantService
    {
        Task CreateRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> GetRestaurantAsync(int restaurantId);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
    }
}
