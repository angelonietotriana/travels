using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings.Events
{
    public sealed record BookingRejectDomainEvent(Guid Id) : IDomainEvent;
}