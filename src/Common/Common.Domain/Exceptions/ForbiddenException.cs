namespace Common.Domain.Exceptions;
public class ForbiddenException : DomainException
{
    public ForbiddenException() 
        : base("Brak uprawnień")
    {
    }
}
