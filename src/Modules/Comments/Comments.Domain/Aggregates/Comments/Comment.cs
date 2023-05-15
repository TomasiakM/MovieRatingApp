using Comments.Domain.Aggregates.Comments.Entities;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Exceptions.Comments;
using Common.Domain.DDD;
using Common.Domain.Exceptions;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Comments;
public sealed class Comment : AggregateRoot
{
    internal const int EditCommentAvailabilityInMinutes = 10;

    public Guid CreatorId { get; private set; }
    public Guid ResourceId { get; init; }
    public CommentContent CommentContent { get; private set; }
    public DateTimeOffset CreatedAt { get; init; }

    private List<Reply> _replies = new();
    public IReadOnlyList<Reply> Replies => _replies.AsReadOnly();

    public Comment(Guid creatorId, Guid resourceId, CommentContent commentContent, IDateProvider dateProvider) 
        : base(Guid.NewGuid())
    {
        CreatorId = creatorId;
        ResourceId = resourceId;
        CommentContent = commentContent;
        CreatedAt = dateProvider.UtcNow;
    }

    public void Update(CommentContent commentContent, Guid updaterId, IDateProvider dateProvider)
    {
        if (CreatorId != updaterId)
        {
            throw new UserCannotUpdateSomeoneCommentException();
        }

        if (CreatedAt.AddMinutes(EditCommentAvailabilityInMinutes) > dateProvider.UtcNow)
        {
            throw new TimeToEditCommentHasExpiredExcpetion(EditCommentAvailabilityInMinutes);
        }

        CommentContent = commentContent;
    }

    public void AddReply(Guid creatorId, CommentContent commentContent, IDateProvider dateProvider)
    {
        var reply = new Reply(creatorId, commentContent, dateProvider);
        _replies.Add(reply);
    }

    public void UpdateReply(Guid replyId, Guid updaterId, CommentContent commentContent, IDateProvider dateProvider)
    {
        var reply = _replies.FirstOrDefault(e => e.Id == replyId);

        if(reply is null)
        {
            throw new NotFoundException();
        }

        reply.Update(updaterId, commentContent, dateProvider);
    }

    private Comment() : base(Guid.NewGuid()) { }
}
