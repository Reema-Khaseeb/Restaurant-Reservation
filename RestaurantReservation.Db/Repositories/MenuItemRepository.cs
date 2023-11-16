﻿using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateMenuItemAsync(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                await _context.MenuItems.AddAsync(menuItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(menuItem));
            }
        }

        public async Task<MenuItem> GetMenuItemAsync(int menuItemId)
        {
            return await _context.MenuItems.FindAsync(menuItemId);
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                _context.MenuItems.Update(menuItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(menuItem));
            }
        }

        public async Task DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
