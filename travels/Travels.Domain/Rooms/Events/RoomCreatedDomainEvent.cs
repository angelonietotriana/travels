using Travels.Domain.Abstractions;

namespace Travels.Domain.Rooms.Events
{
    public sealed record RoomCreatedDomainEvent(Guid RoomId) : IDomainEvent;
}