using Common.Infrastructure.Persistance;
using Movies.Domain.Aggregates.Genres;

namespace Movies.Infrastructure.Persistence.Repositories;
internal sealed class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(MovieDbContext dbContext) 
        : base(dbContext)
    {
    }
}
