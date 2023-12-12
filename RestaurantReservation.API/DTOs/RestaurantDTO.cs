namespace RestaurantReservation.API
{
    public class RestaurantDTO
    {
        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OpeningHours { get; set; }
        public decimal? TotalRevenue { get; set; }
        public ICollection<ReservationDTO>? Reservations { get; set; }
        public ICollection<TableDTO>? Tables { get; set; }
        public ICollection<EmployeeDTO>? Employees { get; set; }
        public ICollection<MenuItemDTO>? MenuItems { get; set; }
    }
}
