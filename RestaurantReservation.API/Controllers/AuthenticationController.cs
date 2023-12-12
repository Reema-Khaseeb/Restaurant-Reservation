using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.DTOs;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthenticationController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginCredentialsDTO LoginCredentials)
        {
            // Validate user credentials
            if (IsValidUser(LoginCredentials))
            {
                // If valid, generate and return a JWT token
                var token = _tokenGenerator.GenerateToken(LoginCredentials);

                return Ok(new { Token = token });
            }

            // If invalid credentials, return an unauthorized response
            return Unauthorized(new { Message = "Invalid username or password" });
        }

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
