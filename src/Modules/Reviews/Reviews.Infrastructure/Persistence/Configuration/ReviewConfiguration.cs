using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.Domain.Aggregates.Reviews;
using Reviews.Domain.Aggregates.Reviews.ValueObjects;

namespace Reviews.Infrastructure.Persistence.Configuration;
internal class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                e => e.Value,
                e => new ReviewId(e));

        builder.Property(e => e.Rating)
            .HasConversion(
                e => e.Value,
                e => new Rating(e));

        builder.Property(e => e.ReviewContent)
            .HasConversion(
                e => e.Value,
                e => new ReviewContent(e));
    }
}
