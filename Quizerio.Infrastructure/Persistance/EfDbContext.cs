using Microsoft.EntityFrameworkCore;
using Quizerio.Infrastructure.Persistance.EntityConfigurations;

namespace Quizerio.Infrastructure.Persistance
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new QuestionConfiguration())
                .ApplyConfiguration(new QuestionCategoryConfiguration());
        }
    }
}