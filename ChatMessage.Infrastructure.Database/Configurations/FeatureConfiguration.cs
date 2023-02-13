using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Infrastructure.Database.Configurations
{
    internal sealed class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {

        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features", "ChatMesssage");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new FeatureId(v));

            builder.Property(e => e.Title).HasMaxLength(128).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(1024);

        }

    }
}
