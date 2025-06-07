using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quizerio.Domain.User.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> configuration)
        {
            configuration
                .HasKey(x => x.Id);

            var rolesConverter = new ValueConverter<List<UserRole>, string>(
                v => string.Join(',', v.Select(r => r.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(r => Enum.Parse<UserRole>(r))
                    .ToList());
            
            configuration
                .Property(x => x.Roles)
                .HasConversion(rolesConverter);

            configuration
                .HasIndex(x => x.Username)
                .HasDatabaseName("User_UserNameIndex")
                .IsUnique();
            
            configuration
                .HasIndex(x => x.Email)
                .HasDatabaseName("User_EmailIndex")
                .IsUnique();

            
            configuration
                .Property(x => x.Created)
                .ValueGeneratedOnAdd();

            configuration
                .Property(x => x.Modified)
                .ValueGeneratedOnUpdate();
        }
    }
}