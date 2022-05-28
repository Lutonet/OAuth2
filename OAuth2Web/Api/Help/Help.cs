using Microsoft.AspNetCore.Mvc;
using OAuth2Web.Helpers;
using Microsoft.Extensions.Localization;
using OAuth2Web.Models;

namespace OAuth2Web.Api.Help
{
    [ApiController]
    public class Help : ControllerBase
    {
        private IUserHelpers _helper;
        public IStringLocalizer<Help> _loc { get; set; }

        public Help(IUserHelpers helper, IStringLocalizer<Help> loc)

        {
            _helper = helper;
            _loc=loc;
        }

        [HttpGet("api/help/{topic}")]
        public IActionResult OnGet(string topic)
        {
            HelperModel helper = _helper.GetHelp(topic);
            HelperModel result = new();
            result.Header = _loc[helper.Header];
            result.BodyText = _loc[helper.BodyText];
            result.Name = helper.Name;
            return Ok(result);
        }
    }
}