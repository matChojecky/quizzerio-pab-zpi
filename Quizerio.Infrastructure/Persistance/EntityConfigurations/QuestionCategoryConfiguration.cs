using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quizerio.Domain.Quiz.Model;

namespace Quizerio.Infrastructure.Persistance.EntityConfigurations
{
    public class QuestionCategoryConfiguration : IEntityTypeConfiguration<QuestionCategory>
    {
        public void Configure(EntityTypeBuilder<QuestionCategory> configuration)
        {
            configuration.ToTable("QuestionCategories");

            configuration
                .HasKey(x => x.Id);

            configuration.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}