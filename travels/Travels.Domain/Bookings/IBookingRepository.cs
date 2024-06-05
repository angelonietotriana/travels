using Travels.Domain.Hotels;
using Travels.Domain.Rooms;

namespace Travels.Domain.Bookings
{

    public interface IBookingRepository
    {
        Task<BookingEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(RoomEntity room,
                                    HotelEntity hotel,
                                    DateRange duracion,
                                    CancellationToken cancellationToken = default);


        void Add(BookingEntity hotel);

        void Update(BookingEntity hotel);
    }
}
