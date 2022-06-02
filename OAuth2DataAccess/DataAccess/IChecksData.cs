namespace OAuth2DataAccess.DataAccess
{
    public interface IChecksData
    {
        Task<bool> EmailAlreadyRegistered(string email);

        Task<bool> NeedsInstall();
    }
}