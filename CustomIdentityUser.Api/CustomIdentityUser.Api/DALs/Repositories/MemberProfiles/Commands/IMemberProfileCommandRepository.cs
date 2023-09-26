using CustomIdentityUser.Api.DALs.Repositories.Bases.Commands;
using CustomIdentityUser.Api.DALs.Tables;

namespace CustomIdentityUser.Api.DALs.Repositories.MemberProfiles.Commands
{
    public interface IMemberProfileCommandRepository : ICommandRepository<MemberProfile>
    { }
}