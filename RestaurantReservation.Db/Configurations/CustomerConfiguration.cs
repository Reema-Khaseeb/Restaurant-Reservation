using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            // Seed data
            builder.HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-3210"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    PhoneNumber = "555-555-5555"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob.brown@example.com",
                    PhoneNumber = "111-222-3333"
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Eve",
                    LastName = "White",
                    Email = "eve.white@example.com",
                    PhoneNumber = "999-888-7777"
                }
                );
        }
    }
}
