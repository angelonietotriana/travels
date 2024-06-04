using Travels.Domain.Abstractions;

namespace Travels.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}