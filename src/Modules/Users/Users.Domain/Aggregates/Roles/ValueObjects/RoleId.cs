using Common.Domain.DDD;

namespace Users.Domain.Aggregates.Roles.ValueObjects;
public sealed class RoleId : ValueObject
{
    public Guid Value { get; init; }

    public RoleId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
