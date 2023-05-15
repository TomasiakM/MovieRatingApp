namespace Common.Domain.DDD;
public class IdItem : ValueObject
{
    public Guid Value { get; init; }

    public IdItem(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
