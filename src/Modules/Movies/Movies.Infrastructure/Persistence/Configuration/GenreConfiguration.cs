﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Genres.ValueObjects;

namespace Movies.Infrastructure.Persistence.Configuration;
internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                e => e.Value,
                e => new GenreId(e));

        builder.Property(e => e.Name)
            .HasMaxLength(32);
    }
}
