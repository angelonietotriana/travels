using Travels.Domain.Abstractions;

namespace Travels.Domain.Hotels.Events
{
    public sealed record HotelRoomNotAvailableDomainEvent(Guid HotelId) : IDomainEvent;

}
