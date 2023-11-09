using RestaurantReservation.Db.Models;
namespace RestaurantReservation.Db.Interfaces
{
    public interface IRestaurantRepository
    {
        Task CreateRestaurantAsync(Restaurant restaurant);
        Task<Restaurant> GetRestaurantAsync(int restaurantId);
        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int restaurantId);
        Task<decimal> CalculateRestaurantTotalRevenueAsync(int restaurantId);
    }
}
