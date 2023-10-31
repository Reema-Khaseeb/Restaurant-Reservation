using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            // Primary Key
            builder.HasKey(r => r.ReservationId);

            // Foreign Keys and Navigation Properties
            builder.HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            builder.HasOne(r => r.Restaurant)
                .WithMany(rest => rest.Reservations)
                .HasForeignKey(r => r.RestaurantId);

            builder.HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId);

            // Seed data
            builder.HasData(
                new Reservation { ReservationId = 1, CustomerId = 1, RestaurantId = 1, 
                    TableId = 1, ReservationDate = DateTime.Now, PartySize = 4 },
                new Reservation { ReservationId = 2, CustomerId = 2, RestaurantId = 2, 
                    TableId = 2, ReservationDate = DateTime.Now, PartySize = 2 },
                new Reservation { ReservationId = 3, CustomerId = 3, RestaurantId = 1, 
                    TableId = 3, ReservationDate = DateTime.Now, PartySize = 6 },
                new Reservation { ReservationId = 4, CustomerId = 4, RestaurantId = 3, 
                    TableId = 4, ReservationDate = DateTime.Now, PartySize = 3 },
                new Reservation { ReservationId = 5, CustomerId = 5, RestaurantId = 4, 
                    TableId = 5, ReservationDate = DateTime.Now, PartySize = 5 }
                );
        }
    }
}
