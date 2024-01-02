using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Db.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace RestaurantReservation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        private readonly IValidator<ReservationDTO> _reservationValidator;

        public ReservationsController(IReservationService reservationService, IMapper mapper, IValidator<ReservationDTO> reservationValidator)
        {
            _reservationService = reservationService ??
                throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _reservationValidator = reservationValidator ??
                throw new ArgumentNullException(nameof(reservationValidator));
        }

        // GET: api/reservations
        /// <summary>
        /// Get all reservations.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved reservations", typeof(IEnumerable<ReservationDTO>))]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        // GET: api/reservations/5
        /// <summary>
        /// Get a reservation by ID.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved reservation", typeof(ReservationDTO))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Reservation not found")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        // POST: api/reservations
        /// <summary>
        /// Create a new reservation.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Successfully created reservation", typeof(ReservationDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data", typeof(IEnumerable<string>))]
        public async Task<ActionResult<ReservationDTO>> CreateReservation(ReservationDTO reservationDto)
        {
            var validationResult = await _reservationValidator.ValidateAsync(reservationDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var reservation = _mapper.Map<Reservation>(reservationDto);
            await _reservationService.CreateReservationAsync(reservation);

            var createdReservationDto = _mapper.Map<ReservationDTO>(reservation);

            return CreatedAtAction(nameof(GetReservation), 
                new { id = createdReservationDto.ReservationId }, 
                createdReservationDto);
        }

        // PATCH: api/reservations/5
        /// <summary>
        /// Update an existing reservation.
        /// </summary>
        [HttpPatch("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully updated reservation")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data")]
        public async Task<IActionResult> UpdateReservation(int id, ReservationDTO reservationDto)
        {
            if (id != reservationDto.ReservationId)
            {
                return BadRequest();
            }

            var reservation = _mapper.Map<Reservation>(reservationDto);
            await _reservationService.UpdateReservationAsync(reservation);

            return NoContent();
        }

        // DELETE: api/reservations/5
        /// <summary>
        /// Delete a reservation by ID.
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successfully deleted reservation")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Reservation not found")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);

            return NoContent();
        }

        // GET: api/reservations/customer/{customerId}
        /// <summary>
        /// Get reservations by customer ID.
        /// </summary>
        [HttpGet("customer/{customerId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved reservations by customer ID", typeof(IEnumerable<ReservationDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Reservations not found for the specified customer")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsByCustomer(int customerId)
        {
            var reservations = await _reservationService.GetReservationsByCustomerAsync(customerId);

            if (!reservations.Any())
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        // GET: api/reservations/details
        /// <summary>
        /// Get reservation details view.
        /// </summary>
        [HttpGet("details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved reservation details view", typeof(IEnumerable<ReservationDetailsViewDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Reservation details view not found")]
        public async Task<ActionResult<IEnumerable<ReservationDetailsViewDTO>>> GetReservationDetailsView()
        {
            var reservations = await _reservationService.GetReservationDetailsViewAsync();

            if (!reservations.Any())
            {
                return NotFound();
            }
            return Ok(reservations);
        }
    }
}
