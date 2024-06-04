using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Booking.Commands
{
    public record BookingCommand(
        Guid RoomsId,
        Guid HotelId,
        Guid UserIdBooking,
        Guid UserIdVendor,
        DateOnly StartDate,
        DateOnly EndDate

    ) : ICommand<Guid>;
}