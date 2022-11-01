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
    public class ParticipantEntityTypeConfiguration : BaseEntityTypeConfiguration<ParticipantEntity>
    {

        public void Configure(EntityTypeBuilder<ParticipantEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.ThreadId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Role).HasDefaultValue(ParticipantRoleEnum.Member);
            builder.Property(x => x.LastSeenAt);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getDate()");

            builder.ToTable($"tbl{nameof(ParticipantEntity)}");
        }
    }
}
