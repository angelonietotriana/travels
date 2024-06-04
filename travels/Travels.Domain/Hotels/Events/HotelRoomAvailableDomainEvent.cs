using Travels.Domain.Abstractions;

namespace Travels.Domain.Hotels.Events
{
    public sealed record HotelRoomAvailableDomainEvent(Guid HotelId) : IDomainEvent;

}
