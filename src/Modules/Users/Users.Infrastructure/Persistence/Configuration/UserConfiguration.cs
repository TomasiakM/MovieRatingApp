using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Roles.ValueObjects;
using Users.Domain.Aggregates.Users;
using Users.Domain.Aggregates.Users.ValueObjects;
using Users.Infrastructure.Services;

namespace Users.Infrastructure.Persistence.Configuration;
internal class Userconfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasConversion(
                e => e.Value,
                e => new UserId(e));

        builder.HasIndex(e => e.UserName)
            .IsUnique();

        builder.HasIndex(e => e.Email)
            .IsUnique();

        builder.Property(e => e.UserName)
            .HasMaxLength(24);

        builder.Property(e => e.Password)
            .HasMaxLength(256);

        builder.Property(e => e.Email)
            .HasMaxLength(256);

        builder.Property(e => e.Image)
            .HasMaxLength(32);

        builder.Metadata.FindNavigation(nameof(User.RoleIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany(e => e.RoleIds, roleIdsBuilder =>
        {
            roleIdsBuilder.ToTable("User_Role");

            roleIdsBuilder.HasKey("Id");
            roleIdsBuilder.WithOwner()
                .HasForeignKey(nameof(UserId));

            roleIdsBuilder.Property(e => e.Id)
                .HasColumnName(nameof(RoleId))
                .ValueGeneratedNever()
                .HasConversion(
                    e => e.Value,
                    e => new(e));

            roleIdsBuilder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(e => e.Id);
        });
    }
}
