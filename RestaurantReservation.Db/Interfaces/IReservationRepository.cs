using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IReservationRepository
    {
        Task CreateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(int reservationId);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationAsync(int reservationId);
        Task UpdateReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
    }
}