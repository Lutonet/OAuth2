using OAuth2DataAccess.Models;
using OAuth2DataAccess.SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.DataAccess
{
    public class RoleData : IRoleData
    {
        private ISQLDataAccess _sql;

        public RoleData(ISQLDataAccess sql)
        {
            _sql = sql;
        }

        public async Task AddAdminDefaultRoles(string applicationId, string userId)
        {
            foreach (var role in DefaultRoles)
            {
                RoleModel model = new RoleModel()
                {
                    ApplicationId = applicationId,
                    Name = role
                };
                try
                {
                    int roleId = await CreateRole(model);
                    UserRoleModel userRole = new UserRoleModel() { RoleId = roleId, UserId = userId };
                    await GiveUserRole(userRole);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public async Task<int> CreateRole(RoleModel role)
        {
            int newId = await _sql.LoadSingleRecord<int, RoleModel>("dbo.spRoleCreate", role);
            return newId;
        }

        public async Task GiveUserRole(UserRoleModel userRole)
        {
            await _sql.SaveData<UserRoleModel>("dbo.spRolesUsers_AddUserRole", userRole);
        }

        public List<string> DefaultRoles = new()
        {
            "Admin",
            "User"
        };
    }
}