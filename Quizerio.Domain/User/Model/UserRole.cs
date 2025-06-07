namespace Quizerio.Domain.User.Model
{
    public enum UserRole
    {
        Standard = 0,
        Moderator = short.MaxValue,
        Admin = int.MaxValue
    }
}