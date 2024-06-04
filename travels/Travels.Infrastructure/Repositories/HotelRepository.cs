using Travels.Domain.Hotels;
using Travels.Domain.Users;

namespace Travels.Infrastructure.Repositories
{

    internal sealed class HotelRepository : Repository<HotelEntity>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}