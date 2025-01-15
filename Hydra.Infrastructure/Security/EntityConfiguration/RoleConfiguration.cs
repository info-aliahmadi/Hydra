using Hydra.Infrastructure.Security.Constants;
using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Infrastructure.Security.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "Auth");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name).HasMaxLength(70);
            builder.Property(o => o.NormalizedName).HasMaxLength(50);
            builder.Property(o => o.ConcurrencyStamp).HasMaxLength(50);
            builder.HasMany(e => e.Permissions).WithMany(x => x.Roles);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            builder.HasData(new Role()
            {
                Id = 1,
                Name = RoleTypes.SUPERADMIN,
                NormalizedName = RoleTypes.SUPERADMIN,
            }, new Role()
            {
                Id = 2,
                Name = RoleTypes.ADMIN,
                NormalizedName = RoleTypes.ADMIN,
            }, new Role()
            {
                Id = 3,
                Name = RoleTypes.USER,
                NormalizedName = RoleTypes.USER,
            }, new Role()
            {
                Id = 4,
                Name = RoleTypes.SUPERVISER,
                NormalizedName = RoleTypes.SUPERVISER,
            }, new Role()
            {
                Id = 5,
                Name = RoleTypes.GUEST,
                NormalizedName = RoleTypes.GUEST,
            });


        }
    }
}
