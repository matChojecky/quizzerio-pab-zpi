using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizerio.Application.User;
using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Dtos;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserFacade userFacade, ILogger<UserController> logger, IMapper mapper)
        {
            _userFacade = userFacade;
            _logger = logger;
            _mapper = mapper;
        }
        
        [Authorize("Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userFacade.GetUsers());
        }


        [Authorize]
        [HttpGet("{userId}")]
        public IActionResult GetUser(Guid userId)
        {
            
            var user = _userFacade.GetUser(
                new GetUserQuery(userId)
            );
                
            return Ok(
                _mapper.Map<UserReadModel>(user)
            );
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] CreateUserCommand command)
        {
            _userFacade.CreateUser(command);
            return CreatedAtAction(null, null);
        }

        [HttpPut("{userId}")]
        public IActionResult PutUser(Guid userId, [FromBody] UserWriteModel userWriteUserModel)
        {
            var current = _userFacade.GetUser(new GetUserQuery(userId));
            
            _userFacade.UpdateUser(
                new UpdateUserCommand(
                    userWriteUserModel.Username,
                    userWriteUserModel.Email,
                    userWriteUserModel.Password,
                    userId
                )
            );
            
            return Ok();
        }

        [HttpGet("{userId}/is-premium")]
        public IActionResult IsPremiumUser(Guid userId)
        {
            return Ok(false);
        }
    }
}