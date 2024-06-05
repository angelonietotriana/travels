using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Hotel.Commands
{
    public record HotelsRoomsCommand(
        Guid HotelId,
        Guid RoomId
    ) : ICommand<Guid>;
}


