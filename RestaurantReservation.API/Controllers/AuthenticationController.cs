using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.DTOs;
using RestaurantReservation.API.Services;
using RestaurantReservation.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantReservation.API.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IJwtTokenGenerator tokenGenerator, IAuthenticationService authenticationService)
        {
            _tokenGenerator = tokenGenerator;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticate user and generate JWT token.
        /// </summary>
        /// <param name="loginCredentials">User login credentials.</param>
        /// <returns>JWT token if authentication is successful.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [Produces("application/json")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully authenticated", Type = typeof(TokenResponseDTO))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Invalid username or password", Type = typeof(ErrorResponseDTO))]
        public IActionResult Login([FromBody] LoginCredentialsDTO LoginCredentials)
        {
            // Validate user credentials
            if (_authenticationService.IsValidUser(LoginCredentials))
            {
                // If valid, generate and return a JWT token
                var token = _tokenGenerator.GenerateToken(LoginCredentials);

                return Ok(new TokenResponseDTO { Token = token });
                //return Ok(new { Token = token });
            }

            // If invalid credentials, return an unauthorized response
            var errorResponse = new ErrorResponseDTO
            {
                ErrorMessage = "Invalid username or password"
            };

            // If invalid credentials, return an unauthorized response
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
}
