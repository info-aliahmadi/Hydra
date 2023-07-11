using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System;

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
            builder.HasMany(e => e.Permissions).WithMany(x=>x.Roles);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

        }
    }
}
