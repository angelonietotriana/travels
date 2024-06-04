using Travels.Application.Abstractions.Clock;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Rooms;

namespace Travels.Application.Rooms.Commands
{

    internal sealed class RoomCommandHandler :
    ICommandHandler<RoomCommand, Guid>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomCommandHandler(IRoomRepository roomRepository,
                                IUnitOfWork unitOfWork)
        {

            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RoomCommand request,
                                                CancellationToken cancellationToken)
        {
            try
            {
                var room = RoomEntity.Create(request!.localization,
                                            request!.numberOfBeds,
                                            request!.capacity,
                                            request!.features,
                                            request!.roomType,
                                            request!.pricePerPeriod,
                                            request!.maintenance,
                                            request!.totalPrice,
                                            request!.featuresPrice,
                                            request!.price);

                _roomRepository.Add(room);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return room.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedRoom);
            }

        }
    }
}