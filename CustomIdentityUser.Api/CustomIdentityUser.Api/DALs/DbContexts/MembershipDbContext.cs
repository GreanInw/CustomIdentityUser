using CustomIdentityUser.Api.DALs.ApplyConfigurations;
using CustomIdentityUser.Api.DALs.Tables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityUser.Api.DALs.DbContexts
{
    public class MembershipDbContext : IdentityDbContext<Member, Role, Guid>, IMembershipDbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyConfiguration(modelBuilder);
        }

        protected internal void ApplyConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuditableConfiguration<Member>());
            builder.ApplyConfiguration(new AuditableConfiguration<Role>());
        }
    }
}