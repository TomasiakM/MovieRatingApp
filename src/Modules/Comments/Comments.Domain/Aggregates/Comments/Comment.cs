using Comments.Domain.Aggregates.Comments.Entities;
using Comments.Domain.Aggregates.Comments.ValueObjects;
using Comments.Domain.Aggregates.Creators.ValueObjects;
using Comments.Domain.Aggregates.Resources.ValueObjects;
using Comments.Domain.Exceptions.Comments;
using Common.Domain.DDD;
using Common.Domain.Exceptions;
using Common.Domain.Interfaces;

namespace Comments.Domain.Aggregates.Comments;
public sealed class Comment : AggregateRoot<CommentId>
{
    internal const int EditCommentAvailabilityInMinutes = 10;

    public CreatorId CreatorId { get; private set; }
    public ResourceId ResourceId { get; init; }
    public CommentContent CommentContent { get; private set; }
    public DateTimeOffset CreatedAt { get; init; }

    private List<Reply> _replies = new();
    public IReadOnlyList<Reply> Replies => _replies.AsReadOnly();

    public Comment(CreatorId creatorId, ResourceId resourceId, CommentContent commentContent, IDateProvider dateProvider) 
        : base(new CommentId())
    {
        CreatorId = creatorId;
        ResourceId = resourceId;
        CommentContent = commentContent;
        CreatedAt = dateProvider.UtcNow;
    }

    public void Update(CommentContent commentContent, CreatorId updaterId, IDateProvider dateProvider)
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

    public void AddReply(CreatorId creatorId, CommentContent commentContent, IDateProvider dateProvider)
    {
        var reply = new Reply(creatorId, commentContent, dateProvider);
        _replies.Add(reply);
    }

    public void UpdateReply(ReplyId replyId, CreatorId updaterId, CommentContent commentContent, IDateProvider dateProvider)
    {
        var reply = _replies.FirstOrDefault(e => e.Id == replyId);

        if(reply is null)
        {
            throw new NotFoundException();
        }

        reply.Update(updaterId, commentContent, dateProvider);
    }

    private Comment() : base(new CommentId()) { }
}
