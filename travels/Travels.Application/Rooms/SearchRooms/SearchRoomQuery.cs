using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.Rooms.SearchRooms
{

    public sealed record SearchRoomQuery(
        DateOnly startDate,
        DateOnly endDate
    ) : IQuery<IReadOnlyList<RoomResponse>>;

}