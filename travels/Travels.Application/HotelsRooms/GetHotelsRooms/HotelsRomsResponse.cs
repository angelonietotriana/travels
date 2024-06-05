namespace Travels.Application.HotelsRooms.GetHotelsRooms
{

    public sealed class HotelsRoomsResponse
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public Guid HotelId { get; set; }

    }
}