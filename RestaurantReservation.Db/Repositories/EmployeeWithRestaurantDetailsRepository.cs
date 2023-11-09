using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeWithRestaurantDetailsRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeWithRestaurantDetailsRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeWithRestaurantDetails>> GetEmployeesWithRestaurantDetailsAsync()
        {
            return await _context.EmployeesWithRestaurantDetails.ToListAsync();
        }
    }

}
