using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.Services
{
    public interface IAuthenticationService
    {
        bool IsValidUser(LoginCredentialsDTO LoginCredentials);
    }
}