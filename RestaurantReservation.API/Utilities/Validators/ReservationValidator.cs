using FluentValidation;

namespace RestaurantReservation.API.Utilities.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationDTO>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.ReservationDate)
                .NotNull()
                .WithMessage("Reservation date is required");
            RuleFor(x => x.PartySize)
                .GreaterThan(0)
                .WithMessage("Party Size must be greater than 0");
        }
    }
}
