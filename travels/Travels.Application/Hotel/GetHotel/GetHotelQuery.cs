using Travels.Application.Abstractions.Messaging;
using Travels.Application.Booking.GetBooking;

namespace Travels.Application.Hotel.GetHotel
{
    public sealed record GetHotelQuery(Guid HotelId) : IQuery<HotelResponse>;
}
