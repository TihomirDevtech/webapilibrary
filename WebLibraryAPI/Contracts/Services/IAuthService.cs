namespace WebLibraryAPI.Contracts.Services;

public interface IAuthService
{
    public Task<string> Login(int memberId, string memberEmail);
}
