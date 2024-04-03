using WebLibraryAPI.Contracts.Services;
using WebLibraryAPI.Repositories;

namespace WebLibraryAPI.Services
{
    public class AuthService(IJwtProvider jwtProvider) : IAuthService
    {
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Login(int memberId, string memberEmail)
        {
            //Generate JWT
            string token = _jwtProvider.Generate(memberId, memberEmail);
            return token;
            //Return JWT
        }
    }
}
