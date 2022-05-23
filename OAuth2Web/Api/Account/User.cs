using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OAuth2DataAccess.Models;
using OAuth2Identity.Models;
using OAuth2Web.Models;

namespace OAuth2Web.Api.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        public User()
        {
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserPublicModel>> Register([FromBody] OAuth2Web.Models.RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                return StatusCode(201, new UserPublicModel());
            }
            return BadRequest(ModelState.ErrorCount);
        }
    }
}