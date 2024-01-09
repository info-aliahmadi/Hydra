using Hydra.Sale.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Sale.Core.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address", "Sale");

            entity.HasIndex(e => e.CountryId, "IX_Address_CountryId");

            entity.HasIndex(e => e.StateProvinceId, "IX_Address_StateProvinceId");

            entity.Property(e => e.Address1).HasMaxLength(300);
            entity.Property(e => e.Address2).HasMaxLength(300);
            entity.Property(e => e.City)
            .IsRequired()
            .HasMaxLength(70);
            entity.Property(e => e.Company).HasMaxLength(300);
            entity.Property(e => e.County).HasMaxLength(70);
            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FaxNumber).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ZipPostalCode).HasMaxLength(30);

            entity.HasOne(d => d.Country).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Address_Country");

            entity.HasOne(d => d.StateProvince).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.StateProvinceId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Address_StateProvince");

            entity.HasOne(d => d.User).WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Address_User");


        }
    }
}
