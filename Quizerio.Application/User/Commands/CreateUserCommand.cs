
using Quizerio.Application.User.Dtos;
using Quizerio.Domain.User.Model;

namespace Quizerio.Application.User.Commands
{
    public class CreateUserCommand : UserWriteModel
    {
        public List<UserRole> Roles { get; set; }

        public CreateUserCommand()
        {
        }

        public CreateUserCommand(
            string username,
            string email,
            string password,
            List<UserRole> role
        ) : base(username, email,
            password)
        {
            Roles = role;
            
        }
        
    }
}