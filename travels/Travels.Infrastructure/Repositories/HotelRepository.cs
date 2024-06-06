using Travels.Domain.Hotels;

namespace Travels.Infrastructure.Repositories
{

    internal sealed class HotelRepository : Repository<HotelEntity>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}