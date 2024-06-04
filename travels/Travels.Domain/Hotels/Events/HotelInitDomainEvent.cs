using Travels.Domain.Abstractions;

namespace Travels.Domain.Hotels.Events
{
    public sealed record HotelInitDomainEvent(Guid HotelId) : IDomainEvent;

}
