﻿namespace RestaurantReservation.API
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int? ReservationId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalAmount { get; set; }
        public ReservationDTO? Reservation { get; set; }
        public EmployeeDTO? Employee { get; set; }
        public ICollection<OrderItemDTO>? OrderItems { get; set; }
    }
}
