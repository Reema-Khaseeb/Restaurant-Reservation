using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            // Primary Key
            builder.HasKey(r => r.RestaurantId);
            builder
                .Property(r => r.TotalRevenue)
                .HasColumnType("DECIMAL(10, 2)");

            // Seed data
            builder.HasData(
                new Restaurant
                {
                    RestaurantId = 1,
                    RestaurantName = "Restaurant A",
                    Address = "123 Main St",
                    PhoneNumber = "555-123-4567",
                    OpeningHours = "9:00 AM - 10:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 2,
                    RestaurantName = "Restaurant B",
                    Address = "456 Elm St",
                    PhoneNumber = "555-987-6543",
                    OpeningHours = "8:00 AM - 9:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 3,
                    RestaurantName = "Restaurant C",
                    Address = "789 Oak St",
                    PhoneNumber = "555-555-5555",
                    OpeningHours = "10:00 AM - 8:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 4,
                    RestaurantName = "Restaurant D",
                    Address = "101 Pine St",
                    PhoneNumber = "555-111-2222",
                    OpeningHours = "7:00 AM - 11:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 5,
                    RestaurantName = "Restaurant E",
                    Address = "234 Cedar St",
                    PhoneNumber = "555-999-8888",
                    OpeningHours = "11:00 AM - 9:00 PM"
                }
                );
        }
    }
}
