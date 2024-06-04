namespace Travels.Api.Controllers.Bookling
{

    public sealed record BookingRequest(
        Guid RoomId,
        Guid HotelId,
        Guid UserIdBooking,
        Guid UserIdVendor,
        DateOnly StartDate,
        DateOnly EndDate
    );
}