namespace OAuth2DataAccess.DataAccess
{
    public interface IChecksData
    {
        Task<bool> NeedsInstall();
    }
}