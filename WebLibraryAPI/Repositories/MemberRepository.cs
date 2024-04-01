using WebLibraryAPI.Models.Auth;

namespace WebLibraryAPI.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public async Task<Member> GetMemberByEmail(string memberEmail)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMemberRepository
    {
        public Task<Member> GetMemberByEmail(string memberEmail);
    }
}
