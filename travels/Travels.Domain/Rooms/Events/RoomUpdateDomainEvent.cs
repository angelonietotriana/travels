using Travels.Domain.Abstractions;

namespace Travels.Domain.Rooms.Events
{
    public sealed record RoomUpdateDomainEvent(Guid RoomId) : IDomainEvent;
}