using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestaurantReservation.API.Services;
using RestaurantReservation.API.Utilities;
using RestaurantReservation.API.Utilities.Extensions;
using RestaurantReservation.API.Utilities.Validators;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Services;
using RestaurantReservation.Validators;
using System.Reflection;
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
            ConfigureAuthentication(services);
            ConfigureAuthorization(services);
            ConfigureAutoMapper(services);
            ConfigureControllers(services);
            ConfigureScopedServices(services);
            ConfigureSwagger(services);
        }


        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            ConfigureSwaggerUI(app);

            //to get more detailed error information
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the Controller to the API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
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
        }

        private void ConfigureAuthorization(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        }

        private void ConfigureScopedServices(IServiceCollection services)
        {
            services.AddScoped<IObjectValidator, ObjectValidator>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<RestaurantReservationDbContext>();

            services.RegisterEntityServices<IReservationService, IReservationRepository,
                ReservationService, ReservationRepository>();
            services.RegisterEntityServices<ICustomerService, ICustomerRepository,
                CustomerService, CustomerRepository>();
            services.RegisterEntityServices<IRestaurantService, IRestaurantRepository,
                RestaurantService, RestaurantRepository>();
            services.RegisterEntityServices<IEmployeeService, IEmployeeRepository,
                EmployeeService, EmployeeRepository>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup), typeof(MappingProfile));
        }

        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv
                .RegisterValidatorsFromAssemblyContaining<ReservationValidator>());
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Restaurant Reservation API",
                    Version = "v1"
                });

                // Include XML comments for Swagger documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private void ConfigureSwaggerUI(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantReservationApiV1");
            });
        }
    }
}
