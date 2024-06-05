using Travels.Application.Abstractions.Clock;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;
using Travels.Domain.HotelsRooms;
using Travels.Domain.Rooms;

namespace Travels.Application.Hotel.Commands
{

    internal sealed class HotelCommandHandler :
    ICommandHandler<HotelCommand, Guid>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelsRoomsRepository _hotelsRoomsRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public HotelCommandHandler(IHotelRepository hotelRepository,
                                   IHotelsRoomsRepository hotelsRoomsRepository,
                                   IRoomRepository roomRepository,
                                   IUnitOfWork unitOfWork,
                                   IDateTimeProvider dateTimeProvider)
        {

            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _hotelsRoomsRepository = hotelsRoomsRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Result<Guid>> Handle(HotelCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var room = _hotelRepository.GetByIdAsync(request.RoomId);

                if (room == null)
                    return Result.Failure<Guid>(HotelErrors.NotFoundRooom);


                var hotel = HotelEntity.Create(
                    request!.Business,
                    request!.Address,
                    request.Capacity,
                    request!.Starts,
                    request.State,
                    DateOnly.FromDateTime(_dateTimeProvider.currentTime)
                );

                _hotelRepository.Add(hotel);

                var hotelsRooms = HotelsRoomsEntity.Create(request.RoomId, hotel.Id, new IsActive(true));

                _hotelsRoomsRepository.Add(hotelsRooms);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return hotel.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedHotel);
            }

        }

      

    }
}