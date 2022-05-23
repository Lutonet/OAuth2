using Microsoft.AspNetCore.Mvc;
using OAuth2I18n.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OAuth2Web.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class Language : ControllerBase
    {
        private I18nConfigurationModel _config;

        public Language(I18nConfigurationModel config)
        {
            _config=config;
        }

        // GET: api/<Language>
        [HttpGet]
        public ActionResult<List<LanguageModel>> Get()
        {
            try
            {
                return Ok(_config.LanguagesSupported);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}