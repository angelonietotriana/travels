using Travels.Application.Abstractions.Clock;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;
using Travels.Domain.Rooms;
using Travels.Domain.Users;

namespace Travels.Application.Booking.Commands
{

    internal sealed class BookingCommandUpdateHandler :
    ICommandHandler<BookingCommandUpdate, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public BookingCommandUpdateHandler(IUserRepository userRepository,
                                            IRoomRepository roomRepository,
                                            IBookingRepository bookingRepository,
                                            IHotelRepository hotelRepository,
                                            PriceService priceService,
                                            IUnitOfWork unitOfWork,
                                            IDateTimeProvider dateTimeProvider)
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result<Guid>> Handle(BookingCommandUpdate request, CancellationToken cancellationToken)
        {

            var userBooking = await _userRepository.GetByIdAsync(request.UserIdBooking, cancellationToken);
            if (userBooking is null)
                return Result.Failure<Guid>(UserErrors.NotFound);

            var userVendor = await _userRepository.GetByIdAsync(request.UserIdShells, cancellationToken);
            if (userVendor is null)
                return Result.Failure<Guid>(UserErrors.NotFound);

            var hotel = await _hotelRepository.GetByIdAsync(request.HotelId, cancellationToken);
            if (hotel is null)
                return Result.Failure<Guid>(BookingErrors.NotFoundHotel);

            var room = await _roomRepository.GetByIdAsync(request.RoomsId, cancellationToken);
            if (room is null)
                return Result.Failure<Guid>(BookingErrors.NotFoundRoom);
            /*
            var duration = DateRange.Create(DateOnly.Parse(request.StartDate), DateOnly.Parse(request.EndDate));
            if (await _bookingRepository.IsOverlappingAsync(room, hotel, duration, cancellationToken))
                return Result.Failure<Guid>(BookingErrors.Overlap);
            */

            var bookingToUpdate = await _bookingRepository.GetByIdAsync(request.BookingId, cancellationToken);
            if (room is null)
                return Result.Failure<Guid>(BookingErrors.NotFoundRoom);


            try
            {
                bookingToUpdate.HotelId = request.HotelId;
                bookingToUpdate.RoomId = request.RoomsId;
                bookingToUpdate.UserIdBooking = request.UserIdBooking;
                bookingToUpdate.UserIdSells = request.UserIdShells;
                bookingToUpdate.Status = request.Status;
                bookingToUpdate.Duration = DateRange.Create(DateOnly.Parse(request.StartDate), DateOnly.Parse(request.EndDate));
                bookingToUpdate.ConfirmDate = DateTime.Parse(request.ConfirmDate);
                bookingToUpdate.RejectDate = DateTime.Parse(request.RejectDate);
                bookingToUpdate.CompleteDate = DateTime.Parse(request.CompleteDate);


                _bookingRepository.Update(bookingToUpdate);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return bookingToUpdate.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.Overlap);
            }

        }
    }
}