using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Primary Key
            builder.HasKey(oi => oi.OrderItemId);

            // Define relationships, constraints, and other configurations
            builder.HasOne(oi => oi.MenuItem)
                .WithMany(mi => mi.OrderItems)
                .HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            builder.HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 2, ItemId = 2, Quantity = 1 },
                new OrderItem { OrderItemId = 3, OrderId = 3, ItemId = 3, Quantity = 3 },
                new OrderItem { OrderItemId = 4, OrderId = 4, ItemId = 4, Quantity = 1 },
                new OrderItem { OrderItemId = 5, OrderId = 5, ItemId = 5, Quantity = 4 }
            );
        }
    }
}
