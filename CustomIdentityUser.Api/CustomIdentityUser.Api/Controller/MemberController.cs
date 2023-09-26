using CustomIdentityUser.Api.DTOs.Registers.Requests;
using CustomIdentityUser.Api.Services.Registers.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CustomIdentityUser.Api.Controller
{
    [ApiController]
    [Route("api/member")]
    public class MemberController : ControllerBase
    {
        private readonly IRegisterMemberCommandService _registerMemberCommandService;

        public MemberController(IRegisterMemberCommandService registerMemberCommandService)
        {
            _registerMemberCommandService = registerMemberCommandService;
        }

        [HttpPost("register")]
        public async ValueTask<IActionResult> Register([FromForm] RegisterRequest request)
        {
            await _registerMemberCommandService.RegisterAsync(request.Username, request.Password);
            return Ok();
        }
    }
}