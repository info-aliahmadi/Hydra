using Hydra.Infrastructure.Setting.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Infrastructure.Setting.EntityConfiguration;

public class SiteSettingConfiguration : IEntityTypeConfiguration<SiteSetting>
{
    public void Configure(EntityTypeBuilder<SiteSetting> builder)
    {
        builder.ToTable("Setting", "Infra");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Key).HasMaxLength(150);

    }
}
