using Quizerio.Application.User.Dtos;
using Quizerio.Domain.User.Model;

namespace Quizerio.Application.User.Commands
{
    public class UpdateUserCommand : UserWriteModel
    {
        public Guid Id { get; set; }
        
        public UpdateUserCommand(string username, string email, string password, Guid id) : base(username, email, password)
        {
            Id = id;
        }
    }
}