using Hydra.Auth.Constants;
using Hydra.Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Auth.EntityConfiguration
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "Auth");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).HasMaxLength(150);
            builder.Property(o => o.NormalizedName).HasMaxLength(150);
            builder.HasMany(e => e.Roles).WithMany(x => x.Permissions);

            builder.HasData(new Permission()
            {
                Id = 1,
                Name = AuthPermissionTypes.AUTH_USER_MANAGEMENT,
                NormalizedName = AuthPermissionTypes.AUTH_USER_MANAGEMENT,
            }, new Permission()
            {
                Id = 2,
                Name = AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT,
                NormalizedName = AuthPermissionTypes.AUTH_PERMISSION_MANAGEMENT,
            });

        }
    }
}
