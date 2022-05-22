using OAuth2DataAccess.DataAccess;
using OAuth2Identity.Controlers;
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
    }
}