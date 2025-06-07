namespace Quizerio.Domain.User.Model
{
    public record UserWriteModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}