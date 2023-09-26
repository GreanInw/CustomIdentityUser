using Microsoft.AspNetCore.Mvc;

namespace CustomIdentityUser.Api.DTOs.Registers.Requests
{
    public class RegisterRequest
    {
        [FromForm]
        public string Username { get; set; }
        [FromForm]
        public string Password { get; set; }
    }
}
