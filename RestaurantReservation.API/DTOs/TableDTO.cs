namespace RestaurantReservation.API
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int? RestaurantId { get; set; }
        public int? Capacity { get; set; }
        public RestaurantDTO? Restaurant { get; set; }
        public ICollection<ReservationDTO>? Reservations { get; set; }
    }
}
