using Travels.Domain.Bookings;

namespace Travels.Api.Controllers.Booking
{

    public sealed record BookingRequest(
        Guid RoomId,
        Guid HotelId,
        Guid UserIdBooking,
        Guid UserIdSells,
        String StartDate,
        String EndDate,
        BookingStatus Status,
        string? ConfirmDate,
        string? RejectDate,
        string? CompleteDate,
        string? CancelationDate
    );
}

