using OAuth2Identity.Models;

namespace OAuth2Identity.Services;

public class RoleService : IRoleService
{
    public async Task<int> CreateRole(string applicationId, string roleName)
    {
        return 0;
    }

    public async Task DeleteRole(string applicationId, string roleName)
    {
        return;
    }

    public async Task<List<RoleModel>> GetAllUserRoles(string userId)
    {
        return new List<RoleModel>();
    }

    public async Task<List<RoleModel>> GetListOfRoles(string applicationId)
    {
        return new List<RoleModel>();
    }

    public async Task<List<RoleModel>> GetRolesForApplication(string applicationId)
    {
        return new List<RoleModel>();
    }

    public async Task<List<RoleModel>> GetUserRoles(string userId, string applicationId)
    {
        return new List<RoleModel>();
    }

    public async Task GiveUserRole(RoleModel role)
    {
    }

    public async Task RemoveUserRole(RoleModel role)
    {
    }
}