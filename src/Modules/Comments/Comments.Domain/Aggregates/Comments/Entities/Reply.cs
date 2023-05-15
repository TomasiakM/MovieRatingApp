using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Exceptions.Comments;
using Common.Domain.DDD;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Comments.Entities;
public sealed class Reply : Entity<ReplyId>
{
    public Guid CreatorId { get; private set; }
    public CommentContent CommentContent { get; private set; }
    public DateTimeOffset CreatedAt { get; init; }

    public Reply(Guid creatorId, CommentContent commentContent, IDateProvider dateProvider)
        : base(new ReplyId())
    {
        CreatorId = creatorId;
        CommentContent = commentContent;
        CreatedAt = dateProvider.UtcNow;
    }

    public void Update(Guid updaterId, CommentContent commentContent, IDateProvider dateProvider)
    {
        if (CreatorId != updaterId)
        {
            throw new UserCannotUpdateSomeoneCommentException();
        }

        if (CreatedAt.AddMinutes(Comment.EditCommentAvailabilityInMinutes) > dateProvider.UtcNow)
        {
            throw new TimeToEditCommentHasExpiredExcpetion(Comment.EditCommentAvailabilityInMinutes);
        }

        CommentContent = commentContent;
    }

    private Reply() : base(new ReplyId()) { }
}
