using Travels.Domain.Rooms;

namespace Travels.Infrastructure.Repositories
{


    internal sealed class RoomRepository : Repository<RoomEntity>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }



    }
}
