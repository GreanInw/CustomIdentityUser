using CustomIdentityUser.Api.DALs.DbContexts;
using CustomIdentityUser.Api.DALs.Repositories.Bases.Queries;
using CustomIdentityUser.Api.DALs.Tables;

namespace CustomIdentityUser.Api.DALs.Repositories.MemberProfiles.Queries
{
    public class MemberProfileQueryRepository : QueryRepository<MemberProfile, IMembershipDbContext>, IMemberProfileQueryRepository
    {
        public MemberProfileQueryRepository(IMembershipDbContext dbContext) : base(dbContext)
        { }
    }
}