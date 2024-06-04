using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Rooms.GetRoom
{
    public sealed record GetRoomQuery(Guid RoomId) : IQuery<RoomResponse>;
}
