using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailOutboxFromAddressConfiguration : IEntityTypeConfiguration<EmailOutboxFromAddress>
    {
        public void Configure(EntityTypeBuilder<EmailOutboxFromAddress> builder)
        {
            builder.ToTable("EmailOutboxFromAddress", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.EmailOutbox).WithMany(x => x.EmailOutboxFromAddress).HasForeignKey(x => x.EmailOutboxId);


        }
    }
}
