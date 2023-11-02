using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(mi => mi.ItemId);

            // Define relationships, constraints, and other configurations
            builder.HasMany(m => m.OrderItems)
                .WithOne(oi => oi.MenuItem)
                .HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            builder.HasData(
                new MenuItem { ItemId = 1, RestaurantId = 1, ItemName = "Dish A", Description = "Delicious dish A", Price = 12.99 },
                new MenuItem { ItemId = 2, RestaurantId = 2, ItemName = "Dish B", Description = "Tasty dish B", Price = 9.99 },
                new MenuItem { ItemId = 3, RestaurantId = 1, ItemName = "Dish C", Description = "Amazing dish C", Price = 15.99 },
                new MenuItem { ItemId = 4, RestaurantId = 3, ItemName = "Dish D", Description = "Special dish D", Price = 10.99 },
                new MenuItem { ItemId = 5, RestaurantId = 4, ItemName = "Dish E", Description = "Exquisite dish E", Price = 14.99 }
            );
        }

    }
}
