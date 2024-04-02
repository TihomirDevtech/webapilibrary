using WebLibraryAPI.Models.Auth;

namespace WebLibraryAPI.Contracts.Services
{
    public interface IJwtProvider
    {
        string Generate(Member member);
    }
}
