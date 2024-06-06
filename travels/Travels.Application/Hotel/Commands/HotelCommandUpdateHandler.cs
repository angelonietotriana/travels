using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;
using Travels.Domain.HotelsRooms;
using Travels.Domain.Rooms;

namespace Travels.Application.Hotel.Commands
{

    internal sealed class HotelCommandUpdateHandler :
    ICommandHandler<HotelCommandUpdated, Guid>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelsRoomsRepository _hotelsRoomsRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;


        public HotelCommandUpdateHandler(IHotelRepository hotelRepository,
                                   IHotelsRoomsRepository hotelsRoomsRepository,
                                   IRoomRepository roomRepository,
                                   IUnitOfWork unitOfWork)
        {

            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
            _hotelsRoomsRepository = hotelsRoomsRepository;
            _roomRepository = roomRepository;
        }

        public async Task<Result<Guid>> Handle(HotelCommandUpdated request, CancellationToken cancellationToken)
        {
            try
            {

                HotelEntity hotelToUpdate = _hotelRepository.GetByIdAsync(request.Id).Result;

                if (hotelToUpdate == null)
                    return Result.Failure<Guid>(HotelErrors.NotFound);

                HotelsRoomsEntity hotelsRoomsToUpdate = _hotelsRoomsRepository.GetByIdsAsync(request.Id, request.RoomId, cancellationToken).Result;


                hotelToUpdate.Business = request.Business;
                hotelToUpdate.Address = request.Address;
                hotelToUpdate.Capacity = request.Capacity;
                hotelToUpdate.Starts = request.Starts;
                hotelToUpdate.State = request.State;

                _hotelRepository.Update(hotelToUpdate);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return hotelToUpdate.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedHotel);
            }

        }



    }
}