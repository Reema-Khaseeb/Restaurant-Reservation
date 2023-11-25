using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task CreateReservationAsync(Reservation reservation);
        Task DeleteReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation> GetReservationAsync(int reservationId);
        Task UpdateReservationAsync(Reservation reservation);
        Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId);
        Task<IEnumerable<ReservationDetailsView>> GetReservationDetailsViewAsync();
    }
}