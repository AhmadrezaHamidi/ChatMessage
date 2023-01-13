using ChatMessage.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatMessage.Infrastructure.Data.Config;

public class ContributorConfiguration : IEntityTypeConfiguration<Contributor>
{
  public void Configure(EntityTypeBuilder<Contributor> builder)
  {
    builder.Property(p => p.Name)
        .HasMaxLength(100)
        .IsRequired();
  }
}
