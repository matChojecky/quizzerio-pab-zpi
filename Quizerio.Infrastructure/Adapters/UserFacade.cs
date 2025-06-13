using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Quizerio.Application;
using Quizerio.Application.User;
using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Model;
using Quizerio.Domain.User.Ports;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Quizerio.Infrastructure.Adapters
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public UserFacade(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IOptions<JwtSettings> jwtOptions)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtSettings = jwtOptions.Value;
        }

        public void CreateUser(CreateUserCommand command)
        {
            var user = new User(
                Guid.NewGuid(),
                command.Username,
                command.Email,
                command.Password,
                command.Roles,
                DateTime.Now,
                DateTime.Now
            );
            
            _userRepository.Add(user);
            _unitOfWork.Commit();
        }

        public void UpdateUser(UpdateUserCommand command)
        {
            var current = _userRepository.GetById(command.Id);

            var updated = new User(
                current.Id,
                command.Username,
                command.Email,
                command.Password,
                current.Roles,
                current.Created,
                DateTime.Now);
            
            _userRepository.Update(updated);
            _unitOfWork.Commit();
        }

        public void DeleteUser(DeleteUserCommand command)
        {
            _userRepository.Delete(command.Id);
            _unitOfWork.Commit();
        }

        public User GetUser(GetUserQuery query)
        {
            return _userRepository.GetById(query.Id);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public string? AuthorizeUser(LoginUserCommand command)
        {
            var user = _userRepository.FindUserByEmail(command.Email);

            if (user == null || user.Password != command.Password)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, user.Username)
            };
            
            claims.AddRange(
                user.Roles.Select(
                    r => new Claim(ClaimTypes.Role, r.ToString())
                )
            );
            
            Console.WriteLine(_jwtSettings.Key);
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Key)
                ),
                SecurityAlgorithms.HmacSha256
            );

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: creds
            );
            
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return token;
        }
    }
}