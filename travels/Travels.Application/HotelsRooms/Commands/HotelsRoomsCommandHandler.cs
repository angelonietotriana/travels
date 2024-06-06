using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;
using Travels.Domain.HotelsRooms;
using Travels.Domain.Rooms;

namespace Travels.Application.HotelsRooms.Commands
{

    internal sealed class HotelsRoomsCommandHandler :
    ICommandHandler<HotelsRoomsCommand, Guid>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelsRoomsRepository _hotelsRoomsRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelsRoomsCommandHandler(IHotelRepository hotelRepository,
                                   IHotelsRoomsRepository hotelsRoomsRepository,
                                   IRoomRepository roomRepository,
                                   IUnitOfWork unitOfWork)
        {

            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _hotelsRoomsRepository = hotelsRoomsRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Result<Guid>> Handle(HotelsRoomsCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var room = _roomRepository.GetByIdAsync(request.RoomId);

                if (room == null)
                    return Result.Failure<Guid>(HotelErrors.NotFoundRooom);

                var hotel = _hotelRepository.GetByIdAsync(request.HotelId);

                if (room == null)
                    return Result.Failure<Guid>(HotelErrors.NotFoundRooom);

                var hotelsRooms = HotelsRoomsEntity.Create(
                    request!.RoomId,
                    request!.HotelId,
                    new IsActive(request.IsActive)
                    );

                _hotelsRoomsRepository.Add(hotelsRooms);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return hotelsRooms.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedRelatedHotelRoom);
            }

        }



    }
}