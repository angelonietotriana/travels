namespace Travels.Domain.HotelsRooms
{
    public interface IHotelsRoomsRepository
    {
        Task<HotelsRoomsEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        public Task<HotelsRoomsEntity> GetByIdsAsync(Guid hotelId,Guid roomId, CancellationToken cancellationToken = default);
        void Add(HotelsRoomsEntity hotel);
        void Update(HotelsRoomsEntity hotel);
    }
}

