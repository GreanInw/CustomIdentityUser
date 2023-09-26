using CustomIdentityUser.Api.DALs.Tables;
using Microsoft.AspNetCore.Identity;

namespace CustomIdentityUser.Api.Services.SignIn.Commands
{
    public class SignInCommandService : ISignInCommandService
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;

        public SignInCommandService(UserManager<Member> userManager, SignInManager<Member> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task SignInAsync(string username, string password)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(username, password, false, true);
            var accessToken = await _userManager.GenerateUserTokenAsync(new Member { }, "", "");
            
        }
    }

    public interface ISignInCommandService
    {
        Task SignInAsync(string username, string password);
    }
}
