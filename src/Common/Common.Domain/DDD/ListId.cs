namespace Common.Domain.DDD;
public sealed class ListId<TId> : ValueObject
    where TId : ValueObject
{
    public TId Id { get; init; }

    public ListId(TId id)
    {
        Id = id;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Id;
    }
}
