using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebLibraryAPI.Contracts.Services;
using WebLibraryAPI.Data;
using WebLibraryAPI.Dtos.Auth;
using WebLibraryAPI.Models.Auth;
using WebLibraryAPI.Services;

namespace WebLibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService, LibraryDbContext libraryDbContext) : Controller
    {
        private readonly IAuthService _authService = authService;
        private readonly LibraryDbContext _libraryDbContext = libraryDbContext;

        [HttpPost]
        public async Task<IActionResult> Login(LoginCreds loginCreds)
        {
            PasswordHasher<LoginCreds> passwordHasher = new();
            var user = _libraryDbContext.Members.FirstOrDefault(x => x.Email == loginCreds.Email);
            if (user is null)
            {
                return NotFound();
            }
            if (passwordHasher.VerifyHashedPassword(loginCreds, user.Password, loginCreds.Password) == PasswordVerificationResult.Success)
            {
                var jwt = await _authService.Login(user.MemberId, user.Email);
                return Ok(jwt);
            }
            return NotFound();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            PasswordHasher<RegisterDto> passwordHasher = new();
            var hashedPass = passwordHasher.HashPassword(registerDto, registerDto.Password);
            //if user exists, return bad request
            Member member = new()
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Password = hashedPass,
                DateJoined = DateOnly.FromDateTime(DateTime.UtcNow),
            };

            _libraryDbContext.Members.Add(member);
            await _libraryDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
