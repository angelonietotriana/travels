using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Booking.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
}
