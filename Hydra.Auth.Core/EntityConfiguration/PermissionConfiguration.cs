using Hydra.Infrastructure.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Auth.Core.EntityConfiguration
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
                Name = "AUTH.CHANGE_PASSWORD",
                NormalizedName = "AUTH.CHANGE_PASSWORD",
            }, new Permission()
            {
                Id = 2,
                Name = "AUTH.GET_USER_LIST",
                NormalizedName = "AUTH.GET_USER_LIST",
            }, new Permission()
            {
                Id = 3,
                Name = "AUTH.GET_USER_BY_ID",
                NormalizedName = "AUTH.GET_USER_BY_ID",
            }, new Permission()
            {
                Id = 4,
                Name = "AUTH.ADD_USER",
                NormalizedName = "AUTH.ADD_USER",
            }, new Permission()
            {
                Id = 5,
                Name = "AUTH.UPDATE_USER",
                NormalizedName = "AUTH.UPDATE_USER",
            }, new Permission()
            {
                Id = 6,
                Name = "AUTH.DELETE_USER",
                NormalizedName = "AUTH.DELETE_USER",
            }, new Permission()
            {
                Id = 7,
                Name = "AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID",
                NormalizedName = "AUTH.ASSIGN_PERMISSION_TO_ROLE_BY_ROLE_ID",
            }, new Permission()
            {
                Id = 8,
                Name = "AUTH.GET_ROLE_LIST",
                NormalizedName = "AUTH.GET_ROLE_LIST",
            }, new Permission()
            {
                Id = 9,
                Name = "AUTH.GET_ROLE_BY_ID",
                NormalizedName = "AUTH.GET_ROLE_BY_ID",
            }, new Permission()
            {
                Id = 10,
                Name = "AUTH.ADD_ROLE",
                NormalizedName = "AUTH.ADD_ROLE",
            }, new Permission()
            {
                Id = 11,
                Name = "AUTH.UPDATE_ROLE",
                NormalizedName = "AUTH.UPDATE_ROLE",
            }, new Permission()
            {
                Id = 12,
                Name = "AUTH.DELETE_ROLE",
                NormalizedName = "AUTH.DELETE_ROLE",
            }, new Permission()
            {
                Id = 13,
                Name = "AUTH.GET_PERMISSION_LIST",
                NormalizedName = "AUTH.GET_PERMISSION_LIST",
            }, new Permission()
            {
                Id = 14,
                Name = "AUTH.GET_PERMISSION_BY_ID",
                NormalizedName = "AUTH.GET_PERMISSION_BY_ID",
            }, new Permission()
            {
                Id = 15,
                Name = "AUTH.ADD_PERMISSION",
                NormalizedName = "AUTH.ADD_PERMISSION",
            }, new Permission()
            {
                Id = 16,
                Name = "AUTH.UPDATE_PERMISSION",
                NormalizedName = "AUTH.UPDATE_PERMISSION",
            }, new Permission()
            {
                Id = 17,
                Name = "AUTH.DELETE_PERMISSION",
                NormalizedName = "AUTH.DELETE_PERMISSION",
            });

        }
    }
}
