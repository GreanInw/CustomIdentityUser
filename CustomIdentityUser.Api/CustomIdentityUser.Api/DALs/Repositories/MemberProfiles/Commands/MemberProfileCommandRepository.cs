using CustomIdentityUser.Api.DALs.DbContexts;
using CustomIdentityUser.Api.DALs.Repositories.Bases.Commands;
using CustomIdentityUser.Api.DALs.Tables;

namespace CustomIdentityUser.Api.DALs.Repositories.MemberProfiles.Commands
{
    public class MemberProfileCommandRepository : CommandRepository<MemberProfile, IMembershipDbContext>, IMemberProfileCommandRepository
    {
        public MemberProfileCommandRepository(IMembershipDbContext dbContext) : base(dbContext) { }
    }
}
