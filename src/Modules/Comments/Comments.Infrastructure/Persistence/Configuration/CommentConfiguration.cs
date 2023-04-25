using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Aggregates.Creators;
using Comments.Domain.Aggregates.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Comments.Infrastructure.Persistence.Configuration;
internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                e => e.Value,
                e => new(e));

        builder.Property(e => e.CommentContent)
            .HasConversion(
                e => e.Value,
                e => new(e));

        builder.Property(e => e.CreatorId)
            .HasConversion(
                e => e.Value,
                e => new(e));
        builder.HasOne<Creator>()
            .WithMany()
            .HasForeignKey(e => e.CreatorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.ResourceId)
            .HasConversion(
                e => e.Value,
                e => new(e));
        builder.HasOne<Resource>()
            .WithMany()
            .HasForeignKey(e => e.ResourceId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Metadata.FindNavigation(nameof(Comment.Replies))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany(e => e.Replies, rb =>
        {
            rb.ToTable("Replies");

            rb.WithOwner()
                .HasForeignKey("CommentId");

            rb.HasKey(e => e.Id);
            rb.Property(e => e.Id)
                .HasConversion(
                    e => e.Value,
                    e => new(e));

            rb.Property(e => e.CommentContent)
                .HasConversion(
                    e => e.Value,
                    e => new(e));

            rb.Property(e => e.CreatorId)
                .HasConversion(
                    e => e.Value,
                    e => new(e));
            rb.HasOne<Creator>()
                .WithMany()
                .HasForeignKey(e => e.CreatorId);
        });
    }
}
