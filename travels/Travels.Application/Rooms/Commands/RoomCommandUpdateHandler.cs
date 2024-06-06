using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Rooms;

namespace Travels.Application.Rooms.Commands
{

    internal sealed class RoomCommandUpdateHandler :
    ICommandHandler<RoomCommandUpdate, Guid>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomCommandUpdateHandler(IRoomRepository roomRepository,
                                IUnitOfWork unitOfWork)
        {

            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RoomCommandUpdate request,
                                                CancellationToken cancellationToken)
        {
            try
            {
                RoomEntity roomToUpdate = _roomRepository.GetByIdAsync(request.RoomId).Result;

                if (roomToUpdate == null)
                    return Result.Failure<Guid>(HotelErrors.NotFoundRooom);

                roomToUpdate.Localization = request.Localization;
                roomToUpdate.NumberOfBeds = request.NumberOfBeds;
                roomToUpdate.Capacity = request.Capacity;
                roomToUpdate.Features = request.Features;
                roomToUpdate.RoomType = request.RoomType;
                roomToUpdate.PricePerPeriod = request.PricePerPeriod;
                roomToUpdate.Maintenance = request.Maintenance;
                roomToUpdate.TotalPrice = request.TotalPrice;
                roomToUpdate.FeaturesPrice = request.FeaturesPrice;
                roomToUpdate.Price = request.Price;


                _roomRepository.Update(roomToUpdate);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return roomToUpdate.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedRoom);
            }

        }
    }
}