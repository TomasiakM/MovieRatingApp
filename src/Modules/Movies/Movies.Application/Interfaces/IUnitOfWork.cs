using Common.Application.Interfaces;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Interfaces;
public interface IUnitOfWork : IBaseUnitOfWork
{
    IMovieRepository Movies { get; }
    IGenreRepository Genres { get; }
}
