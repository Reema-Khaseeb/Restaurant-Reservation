using RestaurantReservation.Db;

using (RestaurantReservationDbContext context = new())
{
    context.Database.EnsureCreated();
}
