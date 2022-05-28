using Microsoft.AspNetCore.Mvc;

namespace OAuth2Web.Api.Help
{
    [ApiController]
    public class Help : ControllerBase
    {
        public Help()
        {
        }

        [HttpGet("api/help/{topic}")]
        public async Task<IActionResult> OnGetAsync(string topic)
        {
            return Ok(topic);
        }
    }
}