using Hydra.Crm.Core.Domain.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Hydra.Crm.Core.EntityConfiguration.Message
{
    public class MessageUserConfiguration : IEntityTypeConfiguration<MessageUser>
    {
        public void Configure(EntityTypeBuilder<MessageUser> builder)
        {
            builder.ToTable("MessageUser", "Crm");

            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Message).WithMany(x => x.MessageUsers).HasForeignKey(x => x.MessageId);



            builder.HasOne(x => x.ToUser).WithMany().HasForeignKey(x => x.ToUserId);

        }
    }
}
