using Common.Domain.Exceptions;

namespace Reviews.Domain.Exceptions.Reviews;
public sealed class ReviewTooLongException : DomainException
{
    public ReviewTooLongException(int maxLength) 
        : base($"Recencja może mieć maksymalnie {maxLength} znaków")
    {
    }
}
