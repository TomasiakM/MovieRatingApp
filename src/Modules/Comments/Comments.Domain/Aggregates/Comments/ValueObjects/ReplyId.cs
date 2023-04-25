using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Comments.ValueObjects;
public sealed class ReplyId : ValueObject
{
    public Guid Value { get; init; }

    public ReplyId()
    {
        Value = Guid.NewGuid();
    }

    public ReplyId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
