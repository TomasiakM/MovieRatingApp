using Common.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Users.Domain.Aggregates.Roles;
using Users.Domain.Aggregates.Users;

namespace Users.Infrastructure.Persistence;
public sealed class UserDbContext : AppDbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    public UserDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("DbConnection"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
