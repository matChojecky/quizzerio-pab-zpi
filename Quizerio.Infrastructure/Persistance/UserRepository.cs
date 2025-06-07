using Quizerio.Domain.User.Model;
using Quizerio.Domain.User.Ports;

namespace Quizerio.Infrastructure.Persistance
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly EfDbContext _context;

        public UserRepository(EfDbContext context) : base(context)
        {
            _context = context;
        }
    }
}