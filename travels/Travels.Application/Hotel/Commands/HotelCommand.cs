using Travels.Application.Abstractions.Messaging;
using Travels.Domain.Hotels;

namespace Travels.Application.Hotel.Commands
{
    public record HotelCommand(
        Business Business,
        Address Address,
        TotalCapacity Capacity,
        Stars Starts,
        HotelStatus State,
        Guid RoomId
    ) : ICommand<Guid>;
}


