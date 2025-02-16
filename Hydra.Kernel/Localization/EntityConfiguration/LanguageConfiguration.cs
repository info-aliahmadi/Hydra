using Hydra.Infrastructure.Localization.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Kernel.Localization.EntityConfiguration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language", "Infra");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).HasMaxLength(70);

        }
    }
}
