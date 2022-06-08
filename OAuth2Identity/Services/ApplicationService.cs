using OAuth2DataAccess.DataAccess;
using OAuth2DataAccess.Models;
using OAuth2Identity.Models;

namespace OAuth2Identity.Services
{
    public class ApplicationService
    {
        private IApplicationData _application;

        public ApplicationService(IApplicationData application)
        {
            _application = application;
        }

        public async Task<Response> CreateApplication(ApplicationModel newApplication)
        {
            // do checks - TODO

            try
            {
                await _application.CreateApplication(newApplication);
                return new Response();
            }
            catch (Exception ex)
            {
                return new Response() { Successfull = false, Message = ex.Message };
            }
        }
    }
}