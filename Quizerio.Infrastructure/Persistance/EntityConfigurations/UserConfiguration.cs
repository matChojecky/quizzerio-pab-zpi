using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizerio.Domain.User.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> configuration)
        {
            configuration
                .HasKey(x => x.Id);

            configuration
                .Property(x => x.Created)
                .ValueGeneratedOnAdd();

            configuration
                .Property(x => x.Modified)
                .ValueGeneratedOnUpdate();
        }
    }
}