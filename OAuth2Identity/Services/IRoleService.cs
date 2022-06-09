using OAuth2Identity.Models;

namespace OAuth2Identity.Services
{
    public interface IRoleService
    {
        Task<int> CreateRole(string applicationId, string roleName);
        Task DeleteRole(string applicationId, string roleName);
        Task<List<RoleModel>> GetAllUserRoles(string userId);
        Task<List<RoleModel>> GetListOfRoles(string applicationId);
        Task<List<RoleModel>> GetRolesForApplication(string applicationId);
        Task<List<RoleModel>> GetUserRoles(string userId, string applicationId);
        Task GiveUserRole(RoleModel role);
        Task RemoveUserRole(RoleModel role);
    }
}