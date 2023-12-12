namespace RestaurantReservation.API
{
    public class MenuItemDTO
    {
        public int ItemId { get; set; }
        public int? RestaurantId { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public RestaurantDTO? Restaurant { get; set; }
        public ICollection<OrderItemDTO>? OrderItems { get; set; }
    }
}
