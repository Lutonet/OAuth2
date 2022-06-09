namespace OAuth2DataAccess.DataAccess
{
    public interface IRoleData
    {
        Task AddAdminDefaultRoles(string applicationId, string userId);
    }
}