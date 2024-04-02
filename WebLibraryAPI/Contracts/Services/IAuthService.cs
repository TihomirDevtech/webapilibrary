namespace WebLibraryAPI.Contracts.Services;

public interface IAuthService
{
    public Task<string> Login(string memberEmail);
}
