using Common.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movies.Domain.Aggregates.Movies;
using System.Reflection;

namespace Movies.Infrastructure.Persistence;
internal sealed class MovieDbContext : AppDbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Movie> Movies => Set<Movie>();
    
    public MovieDbContext(IConfiguration configuration)
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
