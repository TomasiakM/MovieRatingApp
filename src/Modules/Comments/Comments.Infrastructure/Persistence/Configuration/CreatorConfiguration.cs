using Comments.Domain.Aggregates.Creators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Infrastructure.Persistence.Configuration;
internal class CreatorConfiguration : IEntityTypeConfiguration<Creator>
{
    public void Configure(EntityTypeBuilder<Creator> builder)
    {
        builder.ToTable("Creators");

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                e => e.Value,
                e => new(e));

        builder.HasIndex(e => e.UserName)
            .IsUnique();
    }
}
