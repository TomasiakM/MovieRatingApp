using Common.Domain.Exceptions;

namespace Users.Domain.Exceptions.Users;
public sealed class UserHasThisRoleException : DomainException
{
    public UserHasThisRoleException() 
        : base("Użytkownik posiada już tą rolę")
    {
    }
}
