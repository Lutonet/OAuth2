using Microsoft.AspNetCore.Mvc;
using OAuth2DataAccess.Models;
using OAuth2Identity.Services;
using OAuth2Web.Models;

namespace OAuth2Web.Api.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private IUserService _user;

        public User(IUserService user)
        {
            _user = user;
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

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Tokens>> Login([FromBody] LoginModel user)
        {
            if (ModelState.IsValid)
            {   
                
                return Ok(new Tokens());
            }
            else return BadRequest(ModelState.ErrorCount);
        }
    }
}