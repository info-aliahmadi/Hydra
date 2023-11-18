using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailInboxToAddressConfiguration : IEntityTypeConfiguration<EmailInboxToAddress>
    {
        public void Configure(EntityTypeBuilder<EmailInboxToAddress> builder)
        {
            builder.ToTable("EmailInboxToAddress", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailInbox).WithMany(x => x.EmailInboxToAddress).HasForeignKey(x => x.EmailInboxId);


        }
    }
}
