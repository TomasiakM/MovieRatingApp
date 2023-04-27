using Common.Domain.Exceptions;

namespace Reviews.Domain.Exceptions.Reviews;
public sealed class RateNotInRangeException : DomainException
{
    public RateNotInRangeException(int minRate, int maxRate) 
        : base($"Ocena musi mieścić się w zakresie {minRate} - {maxRate}")
    {
    }
}
