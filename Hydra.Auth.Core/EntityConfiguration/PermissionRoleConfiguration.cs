using Hydra.Auth.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
    {
        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder.ToTable("PermissionRole", "Auth");
            builder.HasKey(bc => new { bc.PermissionId, bc.RoleId });

            builder.HasOne(bc => bc.Permission)
                .WithMany(b => b.PermissionRoles)
                .HasForeignKey(bc => bc.PermissionId);

            builder.HasOne(bc => bc.Role)
                .WithMany()
                .HasForeignKey(bc => bc.RoleId);

        }
    }
}
