using CustomIdentityUser.Api.DALs.Auditables;
using CustomIdentityUser.Api.DALs.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityUser.Api.DALs.UnitOfWorks
{
    public abstract class UnitOfWork<TInterfaceDbContext> : IUnitOfWork
        where TInterfaceDbContext : IDbContext
    {
        protected UnitOfWork(TInterfaceDbContext dbContext)
            => DbContext = dbContext;

        protected TInterfaceDbContext DbContext { get; }

        public int Commit() => Commit(true);

        public int Commit(bool acceptAllChangesOnSuccess)
        {
            SetAuditableEntity();
            return DbContext.SaveChanges(acceptAllChangesOnSuccess);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await CommitAsync(true, cancellationToken);

        public async Task<int> CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAuditableEntity();
            return await DbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void Dispose() => DbContext?.Dispose();

        protected virtual void SetAuditableEntity()
        {
            string identityName = Thread.CurrentPrincipal?.Identity?.Name?.ToLower() ?? "";
            var modifiedEntries = from e in DbContext.ChangeTracker.Entries()
                                  where (e.State == EntityState.Added || e.State == EntityState.Modified)
                                  && e.Entity is IAuditableEntity
                                  select e;

            foreach (var entry in modifiedEntries)
            {
                if (entry is null)
                {
                    continue;
                }

                var now = DateTime.UtcNow;
                if (entry.Entity is ICreatedAuditableEntity createdAuditableEntity && entry.State == EntityState.Added)
                {
                    createdAuditableEntity.CreatedBy = identityName;
                    createdAuditableEntity.CreatedDate = now;
                }

                if (entry.Entity is IAuditableEntity auditableEntity)
                {
                    if (entry.State != EntityState.Added)
                    {
                        var createdBy = DbContext.Entry(entry.Entity).Property(nameof(IAuditableEntity.CreatedBy));
                        var createdDate = DbContext.Entry(entry.Entity).Property(nameof(IAuditableEntity.CreatedDate));
                        if (createdBy is not null)
                        {
                            createdBy.IsModified = false;
                        }
                        if (createdDate is not null)
                        {
                            createdDate.IsModified = false;
                        }
                    }

                    auditableEntity.ModifiedBy = identityName;
                    auditableEntity.ModifiedDate = now;
                }
            }
        }
    }
}