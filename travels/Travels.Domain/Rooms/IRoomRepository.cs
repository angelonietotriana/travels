namespace Travels.Domain.Rooms
{
    public interface IRoomRepository
    {
        Task<RoomEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(RoomEntity room);
        void Update(RoomEntity room);
    }
}
