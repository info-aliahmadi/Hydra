using Hydra.Crm.Core.Domain.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Crm.Core.EntityConfiguration.Message
{
    public class MessageConfiguration : IEntityTypeConfiguration<Domain.Message.Message>
    {
        public void Configure(EntityTypeBuilder<Domain.Message.Message> builder)
        {
            builder.ToTable("Message", "Crm");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Name).HasMaxLength(30);

            builder.Property(o => o.Email).HasMaxLength(200);

            builder.Property(o => o.Subject).HasMaxLength(250);


            builder.HasOne(x => x.FromUser).WithMany().HasForeignKey(x => x.FromUserId);

            //builder.HasMany(x => x.MessageUsers).WithOne(x => x.Message).HasForeignKey(x => x.MessageId);


        }
    }
}
