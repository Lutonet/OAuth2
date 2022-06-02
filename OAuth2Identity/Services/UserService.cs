using OAuth2DataAccess.DataAccess;
using OAuth2DataAccess.Models;
using OAuth2Identity.Models;
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

        public async Task CreateServerAdmin(string email, string password)
        {
            if (!await _checks.NeedsInstall())
                return;
            else Console.WriteLine("All OK installing server administrator");
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
    }
}