using RestaurantReservation.Db.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Db.Utilities.Exceptions;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationAsync(int reservationId)
        {
            return await _context.Reservations.FindAsync(reservationId)
                ?? throw new NotFoundException($"Reservation with ID {reservationId} not found.");
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _context.Reservations
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ReservationDetailsView>> GetReservationDetailsViewAsync()
        {
            return await _context.ReservationDetailsViews.ToListAsync();
        }
    }
}
