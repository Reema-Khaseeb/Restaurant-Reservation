using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservation.Db;

var configuration = new ConfigurationBuilder()
            .AddJsonFile("D:\\FTS_internship\\ORM\\Restaurant-Reservation-\\RestaurantReservation\\appsettings.json")
            .Build();

var connectionString = configuration.GetConnectionString("RestaurantReservationDbConnection");

var serviceProvider = new ServiceCollection()
    .AddDbContext<RestaurantReservationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    })
    .BuildServiceProvider();
