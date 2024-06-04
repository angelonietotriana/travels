using Travels.Domain.Users;

namespace Travels.Domain.Users {

    public interface IUserRepository
    {

        Task<UserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(UserEntity user);
    }

}