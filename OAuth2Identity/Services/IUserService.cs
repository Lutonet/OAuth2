using OAuth2DataAccess.Models;
using OAuth2Identity.Models;

namespace OAuth2Identity.Services
{
    public interface IUserService
    {
        Task<bool> CheckEmail(string email);

        bool CheckPassword(string password);

        Task<Response> CreateServerAdmin(string email, string password);

        Task<string> GetUserEmailById(string Id);

        Task<string> GetUserId(string email);

        Task<bool> IsBanned(string UserId);

        Task<bool> IsLocked(string UserId);

        Task<UserPublicModel> Register(IdentityUser register);
    }
}