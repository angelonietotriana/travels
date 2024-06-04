using Travels.Domain.Users;

namespace Travels.Infrastructure.Repositories
{

    internal sealed class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}