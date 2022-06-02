﻿using AutoMapper;
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
    }
}