using Common.Domain.DDD;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Exceptions.Users;

namespace Users.Domain.Aggregates.Users;
public class User : AggregateRoot
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Image { get; private set; } = UserDefaults.Image;

    private List<IdItem> _roleIds = new();
    public IReadOnlyCollection<IdItem> RoleIds => _roleIds.AsReadOnly();

    public User(string userName, string password, string email)
        : base(Guid.NewGuid())
    {
        UserName = userName;
        Password = password;
        Email = email;

        _roleIds.Add(new(Role.UserRoleId));
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    public void AddRole(Guid roleId)
    {
        if (_roleIds.Any(e => e.Value == roleId))
        {
            throw new UserHasThisRoleException();
        }

        _roleIds.Add(new(roleId));
    }

    public void RemoveRole(Guid roleId)
    {
        if(roleId == Role.UserRoleId)
        {
            throw new CanNotRemoveUserRoleException();
        }

        var role = _roleIds.FirstOrDefault(e => e.Value == roleId);

        if (role is null)
        {
            throw new UserDoesNotHaveThisRoleException();
        }

        _roleIds.Remove(role);
    }

    private User() : base(Guid.NewGuid()) { }
}
