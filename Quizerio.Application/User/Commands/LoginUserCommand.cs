namespace Quizerio.Application.User.Commands
{
    public class LoginUserCommand
    {
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
    }
}