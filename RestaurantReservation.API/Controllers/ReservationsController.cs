using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Interfaces;
using RestaurantReservation.Db.Models;
using Microsoft.AspNetCore.Authorization;
using RestaurantReservation.API.Utilities.Validators;
using AutoMapper;
using FluentValidation;

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

        public ReservationsController(IReservationService reservationService, IMapper mapper, ReservationValidator reservationValidator)
        {
            _reservationService = reservationService ??
                throw new ArgumentNullException(nameof(reservationService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _reservationValidator = reservationValidator ??
                throw new ArgumentNullException(nameof(reservationValidator));
        }

        // GET: api/reservations
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        // GET: api/reservations/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {
            var reservation = await _reservationService.GetReservationAsync(id);
            return reservation == null ? NotFound() : Ok(reservation);
        }

        // POST: api/reservations
        [HttpPost]
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
        [HttpPatch("{id}")]
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);

            return NoContent();
        }

        // GET: api/reservations/customer/{customerId}
        [HttpGet("customer/{customerId}")]
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
        [HttpGet("details")]
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
