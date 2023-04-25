using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Comments.ValueObjects;
public sealed class CommentId : ValueObject
{ 
    public Guid Value { get; init; }

    public CommentId()
    {
        Value = Guid.NewGuid();
    }

    public CommentId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
