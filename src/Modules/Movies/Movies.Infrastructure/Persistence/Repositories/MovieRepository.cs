using Common.Infrastructure.Persistance;
using Movies.Domain.Aggregates.Movies;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Infrastructure.Persistence.Repositories;
internal sealed class MovieRepository : Repository<Movie, MovieId>, IMovieRepository
{
    public MovieRepository(MovieDbContext dbContext) 
        : base(dbContext)
    {
    }
}
