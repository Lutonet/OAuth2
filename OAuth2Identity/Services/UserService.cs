using OAuth2DataAccess.DataAccess;
using OAuth2DataAccess.Models;
using OAuth2Identity.Helpers;
using OAuth2Identity.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OAuth2Identity.Services
{
    public class UserService : IUserService
    {
        private IUserData _user;
        private IdentityConfiguration _configuration;
        private IChecksData _checks;

        public UserService(IUserData user,
            IdentityConfiguration configuration,
            IChecksData checks)
        {
            _user = user;
            _configuration=configuration;
            _checks = checks;
        }

        public async Task<Response> CreateServerAdmin(string email, string password)
        {
            if (!await _checks.NeedsInstall())
                return new Response() { Successfull = false, Message = "Installed" };
            else Console.WriteLine("All OK installing server administrator");
            if (!await CheckEmail(email)) return new Response() { Successfull = false, Message = "Email" };
            if (!CheckPassword(password)) return new Response() { Successfull = false, Message = "Password" };

            // all checked, we can run the stored procedure and pray

            PassObject pass = HashPassword(password);
            string applicationKey = Tools.GenerateRandomString(128);
            try
            {
                // register user
                RegisterUserModel newUser = new();
                newUser.Id = Guid.NewGuid().ToString();
                newUser.Email = email;
                newUser.PasswordHash = pass.HashedPassword;
                newUser.PasswordSalt = pass.Salt;
                newUser.FirstName = "Server";
                newUser.LastName = "Admin";
                newUser.PublicName = "Lord of the server";
                newUser.DateOfBirth = DateTime.UtcNow;
                await _user.RegisterUser(newUser);
                // create application

                // assign roles
                // log admin in

                return new Response();
            }
            catch (Exception ex)
            {
                return new Response() { Successfull = false, Message = ex.Message };
            }
        }

        public async Task<string> GetUserEmailById(string Id)
        {
            return null;
        }

        public async Task<string> GetUserId(string email)
        {
            return null;
        }

        public async Task<bool> IsLocked(string UserId)
        {
            return false;
        }

        public async Task<bool> IsBanned(string UserId)
        {
            return false;
        }

        public async Task<UserPublicModel> Register(IdentityUser register)
        {
            return null;
        }

        public async Task<bool> CheckEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                return false;
            }
            return await _user.IsEmailUnique(email);
        }

        public bool CheckPassword(string password)
        {
            // First we check if we use password rules
            if (string.IsNullOrEmpty(password)) return false;
            if (!_configuration.UsePasswordRules) return true;
            if (password.Length < _configuration.PasswordRules.MinimalLength)
                return false;
            if (_configuration.PasswordRules.MustIncludeSmall)
            {
                if (password.ToUpper() == password) return false;
            }
            if (_configuration.PasswordRules.IncludeCapital)
            {
                if (password.ToLower() == password) return false;
            }
            if (_configuration.PasswordRules.IncludeNumber)
            {
                if (!password.Any(char.IsDigit)) return false;
            }
            if (_configuration.PasswordRules.IncludeSpecialCharacter)
            {
                Regex RgxUrl = new Regex("[^a-z0-9]");
                if (!RgxUrl.IsMatch(password)) return false;
            }

            return true;
        }

        private PassObject HashPassword(string password)
        {
            string salt = Tools.GenerateRandomString(16);
            using SHA256 sha = SHA256.Create();
            var asBytes = Encoding.Default.GetBytes($"{password}{salt}");
            var hash = sha.ComputeHash(asBytes);
            return new PassObject { HashedPassword = Convert.ToBase64String(hash), Salt = salt };
        }

        private class PassObject
        {
            public string HashedPassword { get; set; }
            public string Salt { get; set; }
        }
    }
}