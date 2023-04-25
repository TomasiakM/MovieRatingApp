using Common.Infrastructure.Persistance;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Genres.ValueObjects;

namespace Movies.Infrastructure.Persistence.Repositories;
internal sealed class GenreRepository : Repository<Genre, GenreId>, IGenreRepository
{
    public GenreRepository(MovieDbContext dbContext) 
        : base(dbContext)
    {
    }
}
