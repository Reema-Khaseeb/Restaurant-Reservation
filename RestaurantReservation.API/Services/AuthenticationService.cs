using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool IsValidUser(LoginCredentialsDTO LoginCredentials)
        {
            var validUsers = new Dictionary<string, string>
            {
                {"user1", "password1"},
                {"user2", "password2"}
            };

            // Check if the provided username exists and the password matches
            return validUsers.TryGetValue(
                LoginCredentials.Username, out var expectedPassword) &&
                LoginCredentials.Password == expectedPassword;
        }
    }
}
