using WebLibraryAPI.Contracts.Services;
using WebLibraryAPI.Models.Auth;
using WebLibraryAPI.Repositories;

namespace WebLibraryAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly Dictionary<string, string> _users = [];
        public AuthService(IMemberRepository memberRepository, IJwtProvider jwtProvider)
        {
            _memberRepository = memberRepository;
            _jwtProvider = jwtProvider;
            _users.Add("TihomiCiric@gmail.com", "Sifra123");
        }
        public async Task<string> Login(string memberEmail)
        {
            //Get Member
            //var member = await _memberRepository.GetMemberByEmail(memberEmail);
            var member = new Member() { Email = "tc@gmail.com" };
            if (member is null)
            {
                //return not found
            }

            //Generate JWT
            string token = _jwtProvider.Generate(member);
            return token;
            //Return JWT
        }
    }
}
