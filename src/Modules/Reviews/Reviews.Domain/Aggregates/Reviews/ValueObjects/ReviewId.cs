using Common.Domain.DDD;

namespace Reviews.Domain.Aggregates.Reviews.ValueObjects;
public sealed class ReviewId : ValueObject
{
    public Guid Value { get; init; }

    public ReviewId()
    {
        Value = Guid.NewGuid();
    }

    public ReviewId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
