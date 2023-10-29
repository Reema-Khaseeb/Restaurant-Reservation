﻿namespace RestaurantReservation.Db.Models
{
    public class MenuItem
    {
        public int ItemId { get; set; }
        public int RestaurantId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}