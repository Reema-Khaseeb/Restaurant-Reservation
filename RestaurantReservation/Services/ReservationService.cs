using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Validators;

namespace RestaurantReservation.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IObjectValidator _objectValidator;

        public ReservationService(IReservationRepository reservationRepository, IObjectValidator objectValidator)
        {
            _reservationRepository = reservationRepository;
            _objectValidator = objectValidator ?? 
                throw new ArgumentNullException(nameof(objectValidator));
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            _objectValidator.ValidateObjectNotNull(reservation);
            await _reservationRepository.CreateReservationAsync(reservation);
        }

        public async Task<Reservation> GetReservationAsync(int reservationId)
        {
            _objectValidator.ValidatePositiveObjectId(reservationId);
            return await _reservationRepository.GetReservationAsync(reservationId);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _objectValidator.ValidateObjectNotNull(reservation);
            await _reservationRepository.UpdateReservationAsync(reservation);
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetReservationAsync(reservationId);

            _objectValidator.ValidateObjectNotNull(reservation);
            await _reservationRepository.DeleteReservationAsync(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByCustomerAsync(int customerId)
        {
            return await _reservationRepository.GetReservationsByCustomerAsync(customerId);
        }

        public async Task<IEnumerable<ReservationDetailsView>> GetReservationDetailsViewAsync()
        {
            return await _reservationRepository.GetReservationDetailsViewAsync();
        }
    }
}
