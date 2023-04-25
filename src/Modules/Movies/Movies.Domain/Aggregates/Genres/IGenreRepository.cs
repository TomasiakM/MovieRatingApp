using Common.Domain.Interfaces;
using Movies.Domain.Aggregates.Genres.ValueObjects;

namespace Movies.Domain.Aggregates.Genres;
public interface IGenreRepository : IRepository<Genre, GenreId>
{
}
