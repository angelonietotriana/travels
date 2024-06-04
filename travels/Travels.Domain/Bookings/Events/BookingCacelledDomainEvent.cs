using Travels.Domain.Abstractions;

namespace Travels.Domain.Bookings.Events
{
    public sealed record BookingCacelledDomainEvent(Guid Id) : IDomainEvent;
}