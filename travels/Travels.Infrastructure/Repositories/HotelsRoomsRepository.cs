using Travels.Domain.HotelsRooms;

namespace Travels.Infrastructure.Repositories
{


    internal sealed class HotelsRoomsRepository : Repository<HotelsRoomsEntity>, IHotelsRoomsRepository
    {
        public HotelsRoomsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<HotelsRoomsEntity> GetByIdsAsync(Guid hotelId, Guid roomId, CancellationToken cancellationToken = default)
        {

            HotelsRoomsEntity tmp = DbContext.Set<HotelsRoomsEntity>().FirstOrDefault(x => x.HotelId == hotelId && x.RoomId == roomId);
            return tmp ?? new() { };
        }

    }
}
