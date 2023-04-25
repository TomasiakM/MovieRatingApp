using Common.Domain.DDD;
using Users.Domain.Aggregates.Roles.ValueObjects;

namespace Users.Domain.Aggregates.Roles;
public sealed class Role : AggregateRoot<RoleId>
{
    public string Name { get; init; }

    public Role(RoleId id, string name)
        : base(id)
    {
        Name = name;
    }

    private Role() : base(UserRole.Id) { }

    public static Role UserRole => new(new RoleId(new Guid("e38a7da4-d660-4828-987f-1632f968f881")), "User");
    public static Role AdminRole => new(new RoleId(new Guid("d7d80576-4576-4c44-b92b-818e1df8d071")), "Admin");
}
