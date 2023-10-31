using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            // Primary Key
            builder.HasKey(t => t.TableId);

            // Seed data
            builder.HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 2, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 1, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 4 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 5 }
            );
        }
    }
}
