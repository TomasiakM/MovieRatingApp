using Comments.Domain.Exceptions.Comments;
using Common.Domain.DDD;

namespace Comments.Domain.Aggregates.Comments.ValueObjects;
public sealed class CommentContent : ValueObject
{
    public const int MinLength = 10;
    public const int MaxLength = 4000;

    public string Value { get; init; }

    public CommentContent(string value)
    {
        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value) || value.Length < MinLength)
        {
            throw new CommentIsTooShortException(MinLength);
        }

        if(value.Length > MaxLength)
        {
            throw new CommentIsTooLongException(MaxLength);
        }

        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
