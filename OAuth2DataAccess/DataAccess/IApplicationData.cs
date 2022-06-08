using OAuth2DataAccess.Models;

namespace OAuth2DataAccess.DataAccess
{
    public interface IApplicationData
    {
        Task CreateApplication(ApplicationModel newApplication);
    }
}