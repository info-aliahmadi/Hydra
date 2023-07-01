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
            builder.HasMany(e => e.Permissions).WithMany();

        }
    }
}
