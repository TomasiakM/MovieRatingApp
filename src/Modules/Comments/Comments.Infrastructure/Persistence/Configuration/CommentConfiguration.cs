using Comments.Domain.Aggregates.Comments;
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
            .ValueGeneratedNever();

        builder.Property(e => e.CommentContent)
            .HasConversion(
                e => e.Value,
                e => new(e));

        builder.Metadata.FindNavigation(nameof(Comment.Replies))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany(e => e.Replies, rb =>
        {
            rb.ToTable("Replies");

            rb.WithOwner()
                .HasForeignKey("CommentId");

            rb.HasKey(e => e.Id);

            rb.Property(e => e.CommentContent)
                .HasConversion(
                    e => e.Value,
                    e => new(e));
        });
    }
}
