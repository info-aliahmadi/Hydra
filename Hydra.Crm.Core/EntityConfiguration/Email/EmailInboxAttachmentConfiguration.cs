using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailInboxAttachmentConfiguration : IEntityTypeConfiguration<EmailInboxAttachment>
    {
        public void Configure(EntityTypeBuilder<EmailInboxAttachment> builder)
        {
            builder.ToTable("EmailInboxAttachment", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailInbox).WithMany(x => x.EmailInboxAttachments).HasForeignKey(x => x.EmailInboxId);


        }
    }
}
