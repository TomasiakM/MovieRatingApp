using Common.Domain.DDD;

namespace Movies.Domain.Aggregates.Genres.ValueObjects;
public sealed class GenreId : ValueObject
{
    public Guid Value { get; init; }

    public GenreId()
    {
        Value = Guid.NewGuid();
    }

    public GenreId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
