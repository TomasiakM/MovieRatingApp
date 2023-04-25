using Common.Domain.DDD;

namespace Users.Domain.Aggregates.Users.ValueObjects;
public sealed class UserId : ValueObject
{
    public Guid Value { get; init; }

    public UserId()
    {
        Value = Guid.NewGuid();
    }

    public UserId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
