using CustomIdentityUser.Api.DALs.DbContexts;

namespace CustomIdentityUser.Api.DALs.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork<IMembershipDbContext>, IMembershipUnitOfWork
    {
        public MembershipUnitOfWork(IMembershipDbContext dbContext) : base(dbContext) { }
    }
}