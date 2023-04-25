using Common.Domain.Exceptions;

namespace Users.Domain.Exceptions.Users;
public class CanNotRemoveUserRoleException : DomainException
{
    public CanNotRemoveUserRoleException() 
        : base("Nie można usunąć roli User użytkownikowi")
    {
    }
}
