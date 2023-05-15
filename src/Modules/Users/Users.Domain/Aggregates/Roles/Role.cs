using Common.Domain.DDD;

namespace Users.Domain.Aggregates.Roles;
public sealed class Role : AggregateRoot
{
    public string Name { get; init; }

    public Role(Guid id, string name)
        : base(id)
    {
        Name = name;
    }

    private Role() : base(UserRoleId) { }

    public static Guid UserRoleId => new Guid("e38a7da4-d660-4828-987f-1632f968f881");
    public static Guid AdminRoleId => new Guid("e38a7da4-d660-4828-987f-1632f968f882");

    public static Role UserRole => new(UserRoleId, "User");
    public static Role AdminRole => new(AdminRoleId, "Admin");
}
