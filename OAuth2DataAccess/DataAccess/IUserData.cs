using OAuth2DataAccess.Models;

namespace OAuth2DataAccess.DataAccess
{
    public interface IUserData
    {
        Task<IEnumerable<UserModel>> GetUsers();
    }
}