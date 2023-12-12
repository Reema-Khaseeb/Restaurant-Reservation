namespace RestaurantReservation.API
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<ReservationDTO>? Reservations { get; set; }
    }
}
