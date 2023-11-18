using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailInboxConfiguration : IEntityTypeConfiguration<EmailInbox>
    {
        public void Configure(EntityTypeBuilder<EmailInbox> builder)
        {
            builder.ToTable("EmailInbox", "Crm");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Subject).HasMaxLength(250);


        }
    }
}
