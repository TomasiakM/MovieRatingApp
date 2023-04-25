using Common.Domain.Interfaces;
using Movies.Domain.Aggregates.Movies.ValueObjects;

namespace Movies.Domain.Aggregates.Movies;
public interface IMovieRepository : IRepository<Movie, MovieId>
{
}
