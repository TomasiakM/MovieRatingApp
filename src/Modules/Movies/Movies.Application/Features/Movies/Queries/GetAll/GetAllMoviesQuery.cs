using MediatR;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Features.Movies.Queries.GetAll;
public record GetAllMoviesQuery() : IRequest<ICollection<Movie>>;
