using Microsoft.AspNetCore.Mvc;
using WebLibraryAPI.Contracts.Services;
using WebLibraryAPI.Models.Auth;
using WebLibraryAPI.Services;

namespace WebLibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : Controller
    {
        private readonly IAuthService _authService = authService;

        [HttpGet]
        public async Task<IActionResult> LoginMember([FromQuery]LoginCreds loginCreds, CancellationToken token)
        {
            var jwt = await _authService.Login(loginCreds.Email);

            return Ok(jwt);
        }
    }
}
