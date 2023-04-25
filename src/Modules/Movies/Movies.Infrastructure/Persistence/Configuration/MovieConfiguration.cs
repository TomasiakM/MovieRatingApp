using Common.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Genres.ValueObjects;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Infrastructure.Persistence.Configuration;
internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                e => e.Value,
                e => new(e));

        builder.Property(e => e.Title)
            .HasMaxLength(64);

        builder.Property(e => e.Premiere)
            .HasConversion<DateOnlyConverter>();

        builder.Property(e => e.GenreId)
            .HasConversion(
                e => e.Value,
                e => new GenreId(e));

        builder.HasOne<Genre>()
            .WithMany()
            .HasForeignKey(e => e.GenreId);
    }
}
