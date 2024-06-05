using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace Travels.Application.Booking.Commands
{

    public class BookingCommandValidator : AbstractValidator<BookingCommand>
    {
        public BookingCommandValidator()
        {
            RuleFor(c => c.HotelId).NotEmpty();
            RuleFor(c => c.RoomsId).NotEmpty();
            RuleFor(c => c.EndDate).NotEmpty();
            RuleFor(c => c.UserIdBooking).NotEmpty();
            RuleFor(c => c.UserIdShell).NotEmpty();
            RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
            
        }
    }
}