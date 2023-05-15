using Common.Infrastructure.Persistance;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Infrastructure.Persistence.Repositories;
internal sealed class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(MovieDbContext dbContext) 
        : base(dbContext)
    {
    }
}
