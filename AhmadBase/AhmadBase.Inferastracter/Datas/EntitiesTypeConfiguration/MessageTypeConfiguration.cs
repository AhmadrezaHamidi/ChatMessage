using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhmadBase.Inferastracter.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AhmadBase.Inferastracter.Datas.EntitiesTypeConfiguration
{

    public class MessageTypeConfiguration : BaseEntityTypeConfiguration<MessageEntity>
    {
        public override void Configure(EntityTypeBuilder<MessageEntity> entityTypeBuilder)
        {


            entityTypeBuilder.ToTable("Message");
            entityTypeBuilder.Property(b => b.Id).IsRequired();
            entityTypeBuilder.Property(b => b.IsDeleted).HasDefaultValue(0);
            entityTypeBuilder.Property(b => b.CreatedAt).HasDefaultValue(DateTime.Now);
            entityTypeBuilder.Property(b => b.ThreadId).IsRequired();
            entityTypeBuilder.Property(b => b.Body).IsRequired();
            entityTypeBuilder.Property(b => b.HasReplay).HasDefaultValue(false);
            entityTypeBuilder.Property(b => b.Seen).IsRequired();
            entityTypeBuilder.Property(b => b.ReplayMessageId).IsRequired();



            entityTypeBuilder.HasKey(x => x.Id);

            base.Configure(entityTypeBuilder);
        }
    }
}
