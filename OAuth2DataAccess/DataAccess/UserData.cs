using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserData(ISQLDataAccess db, IMapper mapper)
        {
            _db=db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetUsers() =>
           await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

        public async Task<UserPublicModel> GetUserById(string Id)
        {
            var response = await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetById", new { Id = Id });
            return _mapper.Map<UserPublicModel>(response.FirstOrDefault());
        }
    }
}