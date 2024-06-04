using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Travels.Domain.Abstractions;
using Travels.Domain.Hotels.Events;

namespace Travels.Domain.Hotels
{
    public sealed class HotelEntity : Entity
    {
        public Business? Business { get; private set; }
        public Address? Address { get; private set; }
        public TotalCapacity? Capacity { get; private set; }
        public Stars? Starts { get; private set; }
        public HotelStatus? State { get; private set; }
        public DateOnly DateCreated {  get; private set; }

        public HotelEntity() { }

        public HotelEntity(Business? business, Address? address, TotalCapacity? capacity, Stars? starts, HotelStatus? state, DateOnly dateCreated)
        {
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
