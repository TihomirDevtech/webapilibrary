using Microsoft.AspNetCore.Mvc;
using WebLibraryAPI.Models.Auth;
using WebLibraryAPI.Services;

namespace WebLibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> LoginMember([FromQuery]LoginCreds loginCreds, CancellationToken token)
        {
            var jwt = _authService.Login(loginCreds.Email);

            return Ok(jwt);
        }
    }
}
