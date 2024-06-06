using Travels.Domain.Abstractions;
using Travels.Domain.Hotels.Events;

namespace Travels.Domain.Hotels
{
    public sealed class HotelEntity : Entity
    {
        public Business? Business { get; set; }
        public Address? Address { get; set; }
        public TotalCapacity? Capacity { get; set; }
        public Stars? Starts { get; set; }
        public HotelStatus? State { get; set; }
        public DateOnly DateCreated { get; set; }

        public HotelEntity() { }

        public HotelEntity(Business? business,
            Address? address,
            TotalCapacity? capacity,
            Stars? starts,
            HotelStatus? state,
            DateOnly dateCreated)
        {
            Id = Guid.NewGuid();
            Business = business;
            Address = address;
            Capacity = capacity;
            Starts = starts;
            State = state;
            DateCreated = dateCreated;
        }

        public static HotelEntity Create(Business? business,
                        Address? address,
                        TotalCapacity? capacity,
                        Stars? starts,
                        HotelStatus? state,
                        DateOnly dateCreate)
        {
            var _hotel = new HotelEntity(business, address, capacity, starts, state, dateCreate);
            _hotel.RaiseDomainEvent(new HotelInitDomainEvent(_hotel.Id));

            return _hotel;
        }
    }
}
