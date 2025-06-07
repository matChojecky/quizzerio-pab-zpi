using Quizerio.Domain.User.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly EfDbContext _context;

        public UserRepository(EfDbContext context)
        {
            _context = context;
        }
    }
}