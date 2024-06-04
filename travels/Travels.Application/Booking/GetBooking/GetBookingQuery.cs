using Travels.Application.Abstractions.Messaging;
using Travels.Application.Booking.GetBooking;

namespace Travels.Application.Booking.GetBooking
{
    public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;
}
