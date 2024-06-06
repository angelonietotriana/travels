namespace Travels.Api.Controllers.RelatedHotelsRooms
{

    public sealed record HotelsRoomsRequest(
        Guid HotelId,
        Guid RoomId
    );
}
