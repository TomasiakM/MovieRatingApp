using Comments.Domain.Aggregates.Comments;
using Comments.Domain.Aggregates.Creators;
using Common.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Comments.Infrastructure.Persistence;
internal sealed class CommentDbContext : AppDbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Creator> Creators => Set<Creator>();

    public CommentDbContext(IConfiguration configuration)
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
