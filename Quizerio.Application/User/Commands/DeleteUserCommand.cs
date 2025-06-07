namespace Quizerio.Application.User.Commands
{
    public class DeleteUserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        
    }
}