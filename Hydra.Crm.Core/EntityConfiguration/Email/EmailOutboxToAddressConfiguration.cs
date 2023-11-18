using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailOutboxToAddressConfiguration : IEntityTypeConfiguration<EmailOutboxToAddress>
    {
        public void Configure(EntityTypeBuilder<EmailOutboxToAddress> builder)
        {
            builder.ToTable("EmailOutboxToAddress", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailOutbox).WithMany(x => x.EmailOutboxToAddress).HasForeignKey(x => x.EmailOutboxId);


        }
    }
}
