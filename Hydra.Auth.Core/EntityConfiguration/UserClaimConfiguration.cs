using Hydra.Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Auth.EntityConfiguration
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("UserClaim", "Auth");

            builder.Property(o => o.ClaimType).HasMaxLength(50);

            builder.Property(o => o.ClaimValue).HasMaxLength(50);
        }
    }
}
