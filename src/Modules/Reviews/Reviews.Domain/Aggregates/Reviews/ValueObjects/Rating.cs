using Common.Domain.DDD;
using Reviews.Domain.Exceptions.Reviews;

namespace Reviews.Domain.Aggregates.Reviews.ValueObjects;
public sealed class Rating : ValueObject
{
    public const int MinRating = 1;
    public const int MaxRating = 10;

    public int Value { get; init; }

    public Rating(int value)
    {
        if (value < MinRating || value > MaxRating)
        {
            throw new RateNotInRangeException(MinRating, MaxRating);
        }

        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
