using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            // Define relationships, constraints, and other configurations
            builder.HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Reservation)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.ReservationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            builder.HasData(
                new Order { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Now, TotalAmount = 50.0 },
                new Order { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = DateTime.Now, TotalAmount = 30.0 },
                new Order { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = DateTime.Now, TotalAmount = 75.0 },
                new Order { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = DateTime.Now, TotalAmount = 40.0 },
                new Order { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = DateTime.Now, TotalAmount = 60.0 }
            );
        }
    }
}
