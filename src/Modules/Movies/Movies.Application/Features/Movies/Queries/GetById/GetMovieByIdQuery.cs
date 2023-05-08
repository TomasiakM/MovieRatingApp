using MediatR;
using Movies.Application.Dtos.Movies.Responses;

namespace Movies.Application.Features.Movies.Queries.GetById;
public record GetMovieByIdQuery(
    Guid MovieId) : IRequest<MovieResponse>;
