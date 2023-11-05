using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Primary Key
            builder.HasKey(e => e.EmployeeId);

            // Define relationships, constraints, and other configurations
            builder.HasOne(e => e.Restaurant)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed data
            builder.HasData(
                new Employee { EmployeeId = 1, RestaurantId = 1, FirstName = "Employee1", LastName = "Smith", Position = "Server" },
                new Employee { EmployeeId = 2, RestaurantId = 2, FirstName = "Employee2", LastName = "Johnson", Position = "Chef" },
                new Employee { EmployeeId = 3, RestaurantId = 1, FirstName = "Employee3", LastName = "Brown", Position = "Server" },
                new Employee { EmployeeId = 4, RestaurantId = 3, FirstName = "Employee4", LastName = "White", Position = "Manager" },
                new Employee { EmployeeId = 5, RestaurantId = 4, FirstName = "Employee5", LastName = "Green", Position = "Server" }
            );
        }
    }
}
