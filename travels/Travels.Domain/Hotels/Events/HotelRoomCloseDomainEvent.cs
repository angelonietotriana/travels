using Travels.Domain.Abstractions;

namespace Travels.Domain.Hotels.Events
{
    public sealed record HotelRoomCloseDomainEvent(Guid HotelId) : IDomainEvent;

}
