using OAuth2DataAccess.Models;

namespace OAuth2DataAccess.DataAccess
{
    public interface IUserData
    {
        Task<UserPublicModel> GetUserById(string Id);

        Task<IEnumerable<UserModel>> GetUsers();

        Task<bool> IsEmailUnique(string email);

        Task<bool> RegisterUser(RegisterUserModel newUser);
    }
}