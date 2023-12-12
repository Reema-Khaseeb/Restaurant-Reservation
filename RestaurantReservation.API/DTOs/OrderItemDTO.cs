namespace RestaurantReservation.API
{
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public OrderDTO? Order { get; set; }
        public MenuItemDTO? MenuItem { get; set; }
    }
}
