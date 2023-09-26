namespace CustomIdentityUser.Api.Services.Registers.Commands
{
    public interface IRegisterMemberCommandService
    {
        Task RegisterAsync(string username, string password);
    }
}
