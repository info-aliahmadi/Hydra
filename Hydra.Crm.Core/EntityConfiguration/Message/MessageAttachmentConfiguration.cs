using Hydra.Crm.Core.Domain.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Message
{
    public class MessageAttachmentConfiguration : IEntityTypeConfiguration<MessageAttachment>
    {
        public void Configure(EntityTypeBuilder<MessageAttachment> builder)
        {
            builder.ToTable("MessageAttachment", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Message).WithMany(x => x.MessageAttachments).HasForeignKey(x => x.MessageId);


        }
    }
}
