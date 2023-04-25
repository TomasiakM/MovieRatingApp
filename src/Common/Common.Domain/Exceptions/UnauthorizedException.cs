namespace Common.Domain.Exceptions;
public class UnauthorizedException : Exception
{
    public UnauthorizedException()
        : base("Nie udało się zalogować")
    {

    }
}
