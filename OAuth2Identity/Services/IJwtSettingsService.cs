using OAuth2Identity.Models;

namespace OAuth2Identity.Services
{
    public interface IJwtSettingsService
    {
        Task<JwtSettingsModel> Load();
        Task<JwtSettingsModel> Save(JwtSettingsModel model);
    }
}