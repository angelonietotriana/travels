using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings.Events
{
    public sealed record BookingCompleteDomainEvent(Guid Id) : IDomainEvent;
}