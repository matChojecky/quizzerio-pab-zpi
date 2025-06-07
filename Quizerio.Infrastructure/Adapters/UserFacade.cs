using Quizerio.Application;
using Quizerio.Application.User;
using Quizerio.Application.User.Commands;
using Quizerio.Application.User.Queries;
using Quizerio.Domain.Quiz.Ports;
using Quizerio.Domain.User.Model;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Infrastructure.Adapters
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserFacade(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
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
                command.Role,
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
    }
}