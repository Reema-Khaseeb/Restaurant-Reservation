using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(LoginCredentialsDTO loginCredentials);
    }
}