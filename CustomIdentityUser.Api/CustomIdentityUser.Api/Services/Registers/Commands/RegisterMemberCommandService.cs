using CustomIdentityUser.Api.DALs.Tables;
using Microsoft.AspNetCore.Identity;

namespace CustomIdentityUser.Api.Services.Registers.Commands
{
    public class RegisterMemberCommandService : IRegisterMemberCommandService
    {
        private readonly UserManager<Member> _userManager;

        public RegisterMemberCommandService(UserManager<Member> userManager)
        {
            _userManager = userManager;
        }

        public async Task RegisterAsync(string email, string password)
        {
            await _userManager.CreateAsync(new Member
            {
                UserName = email,
                Email = email
            }, password);
        }
    }
}
