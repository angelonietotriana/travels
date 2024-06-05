using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Bookings;

namespace Travels.Application.Booking.Commands
{
    public record BookingCommandUpdate(
        Guid BookingId,
        Guid RoomsId,
        Guid HotelId,
        Guid UserIdBooking,
        Guid UserIdShells,
        string StartDate,
        string EndDate,
        BookingStatus Status,
        string? ConfirmDate,
        string? RejectDate,
        string? CompleteDate,
        string? CancelationDate
    ) : ICommand<Guid>;
}