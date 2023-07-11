using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Infrastructure.Security.EntityConfiguration
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaim", "Auth");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.ClaimType).HasMaxLength(150);
            builder.Property(o => o.ClaimType).HasMaxLength(150);

        }
    }
}
