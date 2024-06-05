using Travels.Application.Abstractions.Messaging;

namespace Travels.Application.HotelsRooms.GetHotelsRooms
{
    public sealed record GetHotelsRoomsQuery(Guid HotelId, Guid RoomId) : IQuery<HotelsRoomsResponse>;
    public sealed record GetHotelRoomQuery(Guid Id) : IQuery<HotelsRoomsResponse>;
}
