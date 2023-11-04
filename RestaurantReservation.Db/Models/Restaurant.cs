﻿namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OpeningHours { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Table>? Tables { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<MenuItem>? MenuItems { get; set; }
    }
}
