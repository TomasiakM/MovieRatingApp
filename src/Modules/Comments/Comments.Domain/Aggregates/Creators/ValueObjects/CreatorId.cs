using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Creators.ValueObjects;
public sealed class CreatorId : ValueObject
{
    public Guid Value { get; init; }

    public CreatorId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
