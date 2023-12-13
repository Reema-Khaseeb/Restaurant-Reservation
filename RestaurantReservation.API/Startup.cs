using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.API.Utilities.Extensions;
using RestaurantReservation.API.Utilities.Validators;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Services;
using RestaurantReservation.Validators;
using System.Text;

namespace RestaurantReservation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Retrieve the secret key from configuration
                    var secretKey = Configuration["Authentication:SecretKey"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.AddAuthorization();
            services.AddSingleton<JwtTokenGenerator>();

            // Scoped services
            services.AddScoped<IObjectValidator, ObjectValidator>();
            services.AddScoped<RestaurantReservationDbContext>();

            // Register repositories and services
            services.RegisterEntityServices<IReservationService, IReservationRepository, 
                ReservationService, ReservationRepository>();
            services.RegisterEntityServices<ICustomerService, ICustomerRepository, 
                CustomerService, CustomerRepository>();
            services.RegisterEntityServices<IRestaurantService, IRestaurantRepository, 
                RestaurantService, RestaurantRepository>();
            services.RegisterEntityServices<IEmployeeService, IEmployeeRepository, 
                EmployeeService, EmployeeRepository>();

            // AutoMapper
            services.AddAutoMapper(typeof(Startup), typeof(MappingProfile));

            // Add Contrllers along with Fluent Validation
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ReservationValidator>());

        }

        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app)
        {
            // Enable authentication
            app.UseAuthentication();

            // Add routing
            app.UseRouting();

            // Add authorization
            app.UseAuthorization();

            // Add the Controller to the API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
