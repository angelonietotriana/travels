using Travels.Application.Abstractions.Clock;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;

namespace Travels.Application.Hotel.Commands
{

    internal sealed class HotelCommandHandler :
    ICommandHandler<HotelCommand, Guid>
{
     private readonly IHotelRepository _hotelRepository;
     private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public HotelCommandHandler(
        IHotelRepository hotelRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
        )
    {

        _hotelRepository = hotelRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

        public async Task<Result<Guid>> Handle(
            HotelCommand request,
            CancellationToken cancellationToken
            )
        {
          
            try
            {
                var hotel = HotelEntity.Create(
                    request!.Business,
                    request!.Address,
                    request.Capacity,
                    request!.Starts,
                    request.State,
                    DateOnly.Parse(_dateTimeProvider.currentTime.ToString())
                );

                _hotelRepository.Add(hotel);

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