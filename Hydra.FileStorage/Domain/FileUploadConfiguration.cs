using Hydra.FileStorage.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Cms.Core.EntityConfiguration
{
    public class FileUploadConfiguration : IEntityTypeConfiguration<FileUpload>
    {
        public void Configure(EntityTypeBuilder<FileUpload> builder)
        {
            builder.ToTable("FileUpload", "FS");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.FileName).HasMaxLength(250);
            builder.Property(o => o.Thumbnail).HasMaxLength(250);
            builder.Property(o => o.Tags).HasMaxLength(100);
            builder.Property(o => o.Alt).HasMaxLength(100);
            builder.Property(o => o.Extension).HasMaxLength(4);


        }
    }
}
