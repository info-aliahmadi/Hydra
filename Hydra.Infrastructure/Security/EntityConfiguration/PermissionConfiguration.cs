using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Infrastructure.Security.EntityConfiguration
{
    public class SettingConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "Auth");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).HasMaxLength(150);
            builder.Property(o => o.NormalizedName).HasMaxLength(150);
            builder.HasMany(e => e.Roles).WithMany(x=>x.Permissions);

        }
    }
}
