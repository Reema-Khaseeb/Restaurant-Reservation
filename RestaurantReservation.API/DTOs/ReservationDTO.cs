namespace RestaurantReservation.API
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public int? CustomerId { get; set; }
        public int? RestaurantId { get; set; }
        public int? TableId { get; set; }
        public DateTime? ReservationDate { get; set; }
        public int? PartySize { get; set; }
        public CustomerDTO? Customer { get; set; }
        public RestaurantDTO? Restaurant { get; set; }
        public TableDTO? Table { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
    }
}
