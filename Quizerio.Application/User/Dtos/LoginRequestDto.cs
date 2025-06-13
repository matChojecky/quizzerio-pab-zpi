namespace Quizerio.Application.User.Dtos
{
    public class LoginRequestDto
    {
        public LoginRequestDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}