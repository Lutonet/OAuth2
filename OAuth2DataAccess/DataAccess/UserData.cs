using AutoMapper;
using OAuth2DataAccess.Models;
using OAuth2DataAccess.SQLAccess;

namespace OAuth2DataAccess.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISQLDataAccess _db;
        private readonly IMapper _mapper;

        public UserData(ISQLDataAccess db, IMapper mapper)
        {
            _mapper = mapper;
            _db=db;
        }

        public async Task<IEnumerable<UserModel>> GetUsers() =>
           await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

        public async Task<UserPublicModel> GetUserById(string Id)
        {
            var response = await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetById", new { Id = Id });
            return _mapper.Map<UserPublicModel>(response.FirstOrDefault());
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            var response = await _db.LoadSingleRecord<int, dynamic>("dbo.spUser_EmailIsUnique", new { email = email });
            if (response != 0) return false;
            return true;
        }

        public async Task<bool> RegisterUser(RegisterUserModel newUser)
        {
            // store user to the DB
            // todo - handle the application
            try
            {
                await _db.SaveData<RegisterUserModel>("dbo.spUser_Insert", newUser);
                // check if some confirmation is needed and do it
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<LoginResponseModel> Login(string UserId, string ApplicationId, string Password)
        {
            UserModel user = await GetUserData(UserId);
            if (user == null)
                return new LoginResponseModel() { Success = false, Error="Not found" };
            if (!await CanLogin(UserId, ApplicationId))
                return new LoginResponseModel() { Success = false, Error="Not allowed" };

            // store user to the DB
            return new LoginResponseModel();
        }

        public async Task<bool> CanLogin(string UserId, string ApplicationId)
        {
            return false;
        }

        private async Task<UserModel> GetUserData(string UserId)
        {
            return new UserModel();
        }

        private async Task<bool> CheckApplicationAccess(string UserId, string ApplicationId)
        {
            return false;
        }
    }
}