namespace Quizerio.Domain.User.Model
{
    public enum UserRole
    {
        Standard = 0,
        Moderator = short.MaxValue / 10,
        Admin = short.MaxValue
    }
}