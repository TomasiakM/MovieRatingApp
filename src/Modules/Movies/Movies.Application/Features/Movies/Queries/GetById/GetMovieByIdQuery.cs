using MediatR;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Features.Movies.Queries.GetById;
public record GetMovieByIdQuery(
    Guid MovieId) : IRequest<Movie>;
