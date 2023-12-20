using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Services;
using RestaurantReservation.Services;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IJwtTokenGenerator tokenGenerator, IAuthenticationService authenticationService)
        {
            _tokenGenerator = tokenGenerator;
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginCredentialsDTO LoginCredentials)
        {
            // Validate user credentials
            if (_authenticationService.IsValidUser(LoginCredentials))
            {
                // If valid, generate and return a JWT token
                var token = _tokenGenerator.GenerateToken(LoginCredentials);

                return Ok(new { Token = token });
            }

            // If invalid credentials, return an unauthorized response
            return Unauthorized(new { Message = "Invalid username or password" });
        }
            {
                ErrorMessage = "Invalid username or password"
            };

            // If invalid credentials, return an unauthorized response
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
}
