using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings.Events
{
    public sealed record BookingDomainEvent(Guid Id) : IDomainEvent;
}