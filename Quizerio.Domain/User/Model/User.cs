namespace Quizerio.Domain.User.Model
{
    public class User
    {
        public User(
            Guid id,
            string username,
            string email,
            string password,
            List<UserRole> roles,
            DateTime created,
            DateTime modified
        )
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            Roles = roles;
            Created = created;
            Modified = modified;
        }

        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public List<UserRole> Roles { get; private set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; private set; }
    }
}