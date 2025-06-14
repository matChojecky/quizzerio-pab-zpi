using Quizerio.Domain.Common;

namespace Quizerio.Domain.User.Ports
{
    public interface IUserRepository : IRepository<Model.User>
    {
        Model.User? FindUserByEmail(string email);
    }
}