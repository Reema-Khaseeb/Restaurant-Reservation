using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Services
{
    public class ReservationDetailsViewService
    {
        private readonly ReservationDetailsViewRepository _reservationDetailsViewRepository;

        public ReservationDetailsViewService(ReservationDetailsViewRepository reservationDetailsViewRepository)
        {
            _reservationDetailsViewRepository = reservationDetailsViewRepository;
        }

        public async Task<IEnumerable<ReservationDetailsView>> GetReservationDetailsViewAsync()
        {
            return await _reservationDetailsViewRepository.GetReservationDetailsViewAsync();
        }
    }
}
