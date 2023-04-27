using Common.Domain.Exceptions;

namespace Reviews.Domain.Exceptions.Reviews;
public class ReviewTooShortException : DomainException
{
    public ReviewTooShortException(int minLength) 
        : base($"Recenzja musi mieć co najmniej {minLength} znaków")
    {
    }
}
