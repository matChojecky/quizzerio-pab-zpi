using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.User;
using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Dtos;

namespace Quizerio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserFacade _usersFacade;

        public AuthController(IUserFacade usersFacade)
        {
            _usersFacade = usersFacade;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            var token = _usersFacade.AuthorizeUser(new LoginUserCommand(request.Email, request.Password));

            if (token is null)
            {
                return Unauthorized();
            }
            
            
            return Ok(new { access_token = token });
            
        }
    }
}