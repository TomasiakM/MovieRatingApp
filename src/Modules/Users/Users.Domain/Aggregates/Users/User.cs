using Common.Domain.DDD;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Roles.ValueObjects;
using Users.Domain.Aggregates.Users.ValueObjects;
using Users.Domain.Exceptions.Users;

namespace Users.Domain.Aggregates.Users;
public class User : AggregateRoot<UserId>
{
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Image { get; private set; } = UserDefaults.Image;

    private List<ListId<RoleId>> _roleIds = new();
    public IReadOnlyCollection<ListId<RoleId>> RoleIds => _roleIds.AsReadOnly();

    public User(string userName, string password, string email)
        : base(new UserId())
    {
        UserName = userName;
        Password = password;
        Email = email;

        _roleIds.Add(new ListId<RoleId>(Role.UserRole.Id));
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    public void AddRole(RoleId roleId)
    {
        if (_roleIds.Any(e => e == roleId))
        {
            throw new UserHasThisRoleException();
        }

        _roleIds.Add(new ListId<RoleId>(roleId));
    }

    public void RemoveRole(RoleId roleId)
    {
        if(roleId == Role.UserRole.Id)
        {
            throw new CanNotRemoveUserRoleException();
        }

        var role = _roleIds.FirstOrDefault(e => e.Id == roleId);

        if (role is null)
        {
            throw new UserDoesNotHaveThisRoleException();
        }

        _roleIds.Remove(role);
    }

    private User() : base(new UserId()) { }
}
