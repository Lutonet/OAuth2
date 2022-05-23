using OAuth2DataAccess.DataAccess;
using OAuth2Identity.Controlers;
using OAuth2Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Services
{
    public class UserService
    {
        private UserData _user;

        public UserService(UserData user)
        {
            _user=user;
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

        public async Task<string> Register(IdentityUser register)
        {
            return null;
        }
    }
}