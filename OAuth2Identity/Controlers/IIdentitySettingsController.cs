namespace OAuth2Identity.Controlers
{
    public interface IIdentitySettingsController
    {
        Task<IdentityConfiguration> Load();

        Task Save(IdentityConfiguration settings);
    }
}