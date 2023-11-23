using Hydra.Crm.Core.Domain.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Email
{
    public class EmailOutboxConfiguration : IEntityTypeConfiguration<EmailOutbox>
    {
        public void Configure(EntityTypeBuilder<EmailOutbox> builder)
        {
            builder.ToTable("EmailOutbox", "Crm");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Subject).HasMaxLength(250);


        }
    }
}
