using Common.Domain.Exceptions;

namespace Users.Domain.Exceptions.Users;
public sealed class UserDoesNotHaveThisRoleException : DomainException
{
    public UserDoesNotHaveThisRoleException() 
        : base("Użytkownik nie posida tej roli")
    {
    }
}
