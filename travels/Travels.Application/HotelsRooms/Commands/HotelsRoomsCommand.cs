using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.HotelsRooms.Commands
{
    public record HotelsRoomsCommand(
        Guid HotelId,
        Guid RoomId,
        bool IsActive
    ) : ICommand<Guid>;
}


