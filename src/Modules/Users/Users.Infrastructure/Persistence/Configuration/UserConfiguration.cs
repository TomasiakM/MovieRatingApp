using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Users;

namespace Users.Infrastructure.Persistence.Configuration;
internal class Userconfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

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
            .HasMaxLength(64);

        builder.Metadata.FindNavigation(nameof(User.RoleIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.OwnsMany(e => e.RoleIds, roleIdsBuilder =>
        {
            roleIdsBuilder.ToTable("User_Role");

            roleIdsBuilder.WithOwner()
                .HasForeignKey("UserId");

            roleIdsBuilder.Property(e => e.Value)
                .HasColumnName("RoleId")
                .ValueGeneratedNever();

            roleIdsBuilder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(e => e.Value);
        });
    }
}
