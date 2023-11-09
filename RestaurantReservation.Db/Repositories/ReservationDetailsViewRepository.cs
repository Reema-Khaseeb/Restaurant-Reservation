using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationDetailsViewRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationDetailsViewRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationDetailsView>> GetReservationDetailsViewAsync()
        {
            return await _context.ReservationDetailsViews.ToListAsync();
        }

    }
}
