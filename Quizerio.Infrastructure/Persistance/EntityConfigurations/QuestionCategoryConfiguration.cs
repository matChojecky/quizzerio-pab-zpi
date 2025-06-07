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

            configuration.HasMany(c => c.Questions)
                .WithOne(q => q.Category)
                .HasForeignKey(q => q.Category.Id);
        }
    }
}