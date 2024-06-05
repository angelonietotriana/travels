using Travels.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Travels.Infrastructure.Repositories {


    internal abstract class Repository<T>
    where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default
        )
        {
            return await DbContext.Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Update(entity);
        }

     }
}
