using Common.Domain.DDD;

namespace Movies.Domain.Aggregates.Movies.ValueObjects;
public sealed class MovieId : ValueObject
{
    public Guid Value { get; init; }

    public MovieId()
    {
        Value = Guid.NewGuid();
    }

    public MovieId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
