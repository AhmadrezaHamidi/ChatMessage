using ChatMesssage.Domain.Core;
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
    internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "ChatMesssage");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new CategoryId(v));

            builder.Property(e => e.CategoryName)
            .HasMaxLength(128).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(1024);

            builder.OwnsOne(s => s.Thumbnail, y =>
            {
                //write Value Object Configuraion
                y.Property(e => e.Extension).HasMaxLength(16).IsRequired();
                y.Property(e => e.FileName).HasMaxLength(128).IsRequired();
                y.Property(e => e.FilePath).HasMaxLength(512).IsRequired();
            });

            builder.OwnsMany(s => s.CategoryFeatures, y =>
            {
                y.WithOwner().HasForeignKey("CategoryId");

                y.ToTable("CategoryFeatures", "ChatMesssage");

                y.Property(x => x.CategoryId)
                .HasConversion(
                    v => v.Value,
                    v => new CategoryId(v));

                y.Property(x => x.FeatureId)
                .HasConversion(
                    v => v.Value,
                    v => new FeatureId(v));

                y.HasKey("CategoryId", "FeatureId");

            });


        }
    }
}
