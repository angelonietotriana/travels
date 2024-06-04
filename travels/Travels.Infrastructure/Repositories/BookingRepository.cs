using Microsoft.EntityFrameworkCore;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;
using Travels.Domain.Rooms;

namespace Travels.Infrastructure.Repositories
{

    internal sealed class BookingRepository : Repository<BookingEntity>, IBookingRepository
    {
        private static readonly BookingStatus[] ActiveBookingStatuses = {
        BookingStatus.Booking,
        BookingStatus.Confirm,
        BookingStatus.Complete
    };

        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverlappingAsync(
            RoomEntity room,
            HotelEntity hotel,
            DateRange duracion,
            CancellationToken cancellationToken = default)
        {

            return await DbContext.Set<BookingEntity>()
            .AnyAsync(
                booking =>
                    booking.HotelId == hotel.Id &&
                    booking.Duration!.Start <= duracion.End &&
                    booking.Duration.End >= duracion.Start &&
                    ActiveBookingStatuses.Contains(booking.Status),
                    cancellationToken
            );
        }
    }
}