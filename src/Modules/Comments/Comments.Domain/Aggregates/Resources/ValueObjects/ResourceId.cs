using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Resources.ValueObjects;
public sealed class ResourceId : ValueObject
{
    public Guid Value { get; init; }

    public ResourceId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
