using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailInboxFromAddressConfiguration : IEntityTypeConfiguration<EmailInboxFromAddress>
    {
        public void Configure(EntityTypeBuilder<EmailInboxFromAddress> builder)
        {
            builder.ToTable("EmailInboxFromAddress", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailInbox).WithMany(x => x.EmailInboxFromAddress).HasForeignKey(x => x.EmailInboxId);


        }
    }
}
