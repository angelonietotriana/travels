using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings.Events
{
    public sealed record BookingConfirmDomainEvent(Guid Id) : IDomainEvent;
}