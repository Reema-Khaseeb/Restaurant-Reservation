﻿using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(restaurant));
            }
        }

        public async Task<Restaurant> GetRestaurantAsync(int restaurantId)
        {
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task UpdateRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                _context.Restaurants.Update(restaurant);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(restaurant));
            }
        }

        public async Task DeleteRestaurantAsync(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<decimal> CalculateRestaurantTotalRevenueAsync(int restaurantId)
        {
            var result = await _context.Restaurants
                .FromSqlInterpolated($"SELECT dbo.CalculateRestaurantTotalRevenue({restaurantId}) AS TotalRevenue")
                .Select(rt => rt.TotalRevenue)
                .FirstOrDefaultAsync();

            return result ?? 0;
        }
    }
}
