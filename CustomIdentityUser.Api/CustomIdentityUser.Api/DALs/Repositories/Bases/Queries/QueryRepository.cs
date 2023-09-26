using CustomIdentityUser.Api.DALs.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityUser.Api.DALs.Repositories.Bases.Queries
{
    public abstract class QueryRepository<TEntity, TEFCoreDbContext> : IQueryRepository<TEntity>
        where TEntity : class
        where TEFCoreDbContext : IDbContext
    {
        public QueryRepository(TEFCoreDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected TEFCoreDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public IQueryable<TEntity> All => DbSet.AsQueryable();

        public void Dispose() => DbContext.Dispose();

        public async Task ReloadAsync(TEntity entity) => await DbContext.Entry(entity).ReloadAsync();

        public TEntity GetById(params object[] keyValues) => DbSet.Find(keyValues);

        public async ValueTask<TEntity> GetByIdAsync(params object[] keyValues) => await DbSet.FindAsync(keyValues);
    }
}
