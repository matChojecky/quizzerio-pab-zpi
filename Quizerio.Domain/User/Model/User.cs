namespace Quizerio.Domain.User.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<UserRole> Roles { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}