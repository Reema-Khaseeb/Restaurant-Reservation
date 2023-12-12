namespace RestaurantReservation.API
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int? RestaurantId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public RestaurantDTO? Restaurant { get; set; }
        public ICollection<OrderDTO>? Orders { get; set; }
    }

}
