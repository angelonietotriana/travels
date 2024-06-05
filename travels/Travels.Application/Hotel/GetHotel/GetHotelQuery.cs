using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Hotel.GetHotel
{
    public sealed record GetHotelQuery(Guid HotelId) : IQuery<HotelResponse>;
}
