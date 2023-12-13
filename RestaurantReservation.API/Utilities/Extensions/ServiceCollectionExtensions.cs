namespace RestaurantReservation.API.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterEntityServices<TService, TRepository, TServiceImplementation, TRepositoryImplementation>(
            this IServiceCollection services)
            where TService : class
            where TRepository : class
            where TServiceImplementation : class, TService
            where TRepositoryImplementation : class, TRepository
        {
            services.AddScoped<TRepository, TRepositoryImplementation>();
            services.AddScoped<TService, TServiceImplementation>();
        }
    }
}
