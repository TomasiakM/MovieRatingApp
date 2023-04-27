using Common.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reviews.Domain.Aggregates.Reviews;
using System.Reflection;

namespace Reviews.Infrastructure.Persistence;
internal sealed class ReviewDbContext : AppDbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Review> Reviews => Set<Review>();

    public ReviewDbContext(IConfiguration configuration)
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
