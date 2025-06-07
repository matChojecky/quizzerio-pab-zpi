using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.User;
using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Dtos;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserFacade userFacade, ILogger<UserController> logger)
        {
            _userFacade = userFacade;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userFacade.GetUsers());
        }


        [HttpGet("{userId}")]
        public IActionResult GetUser(Guid userId)
        {
            return Ok(
                _userFacade.GetUser(
                    new GetUserQuery(userId)
                )
            );
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] CreateUserCommand command)
        {
            _userFacade.CreateUser(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{userId}")]
        public IActionResult PutUser(Guid userId, [FromBody] UserDto userModel)
        {
            var current = _userFacade.GetUser(new GetUserQuery(userId));
            
            _userFacade.UpdateUser(
                new UpdateUserCommand(
                    userModel.Username,
                    userModel.Email,
                    userModel.Password,
                    userId
                )
            );
            
            return Ok();
        }
    }
}