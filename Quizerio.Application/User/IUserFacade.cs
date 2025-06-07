using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.User.Model;

namespace Quizerio.Application.User
{
    public interface IUserFacade
    {
        void CreateUser(CreateUserCommand command);

        void UpdateUser(UpdateUserCommand command);

        void DeleteUser(DeleteUserCommand command);
        
        Domain.User.Model.User GetUser(GetUserQuery query);
        
        List<Domain.User.Model.User> GetUsers();
        
    }
}