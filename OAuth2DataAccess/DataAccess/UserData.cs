using OAuth2DataAccess.Models;
using OAuth2DataAccess.SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISQLDataAccess _db;

        public UserData(ISQLDataAccess db)
        {
            _db=db;
        }

        public async Task<IEnumerable<UserModel>> GetUsers() =>
           await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
    }
}