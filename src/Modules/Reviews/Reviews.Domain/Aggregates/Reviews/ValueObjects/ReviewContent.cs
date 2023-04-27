using Common.Domain.DDD;
using Reviews.Domain.Exceptions.Reviews;

namespace Reviews.Domain.Aggregates.Reviews.ValueObjects;
public sealed class ReviewContent : ValueObject
{
    public const int MinLength = 10;
    public const int MaxLength = 4000;

    public string Value { get; init; }

    public ReviewContent(string value)
    {
        value = value.Trim();

        if(value.Length < MinLength)
        {
            throw new ReviewTooShortException(MinLength);
        }

        if(value.Length > MaxLength)
        {
            throw new ReviewTooLongException(MaxLength);
        }

        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
