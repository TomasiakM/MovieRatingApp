using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.Persistance;
public class AppDbContext : DbContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
