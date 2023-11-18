using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailOutboxAttachmentConfiguration : IEntityTypeConfiguration<EmailOutboxAttachment>
    {
        public void Configure(EntityTypeBuilder<EmailOutboxAttachment> builder)
        {
            builder.ToTable("EmailOutboxAttachment", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailOutbox).WithMany(x => x.EmailOutboxAttachments).HasForeignKey(x => x.EmailOutboxId);


        }
    }
}
