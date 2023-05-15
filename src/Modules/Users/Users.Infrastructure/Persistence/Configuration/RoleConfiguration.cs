using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain.Aggregates.Roles;

namespace Users.Infrastructure.Persistence.Configuration;
internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .HasMaxLength(32);

        builder.HasIndex(e => e.Name)
            .IsUnique();

        builder.HasData(Role.UserRole, Role.AdminRole);
    }
}
