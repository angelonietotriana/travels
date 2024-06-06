using Travels.Domain.Abstractions;

namespace Travels.Domain.HotelsRooms
{
    public sealed class HotelsRoomsEntity : Entity
    {
        public Guid RoomId { get; private set; }
        public Guid HotelId { get; private set; }
        public IsActive IsActive { get; set; }
        public HotelsRoomsEntity() { }

        public HotelsRoomsEntity(Guid roomId, Guid hotelId, IsActive isActive)
        {
            RoomId = roomId;
            HotelId = hotelId;
            IsActive = isActive;
        }

        public static HotelsRoomsEntity Create(Guid roomId, Guid hotelId, IsActive isActive)
        {
            return new HotelsRoomsEntity(roomId, hotelId, isActive);

        }
    }
}
