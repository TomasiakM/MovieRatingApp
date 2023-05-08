using MediatR;
using Movies.Application.Dtos.Movies.Responses;

namespace Movies.Application.Features.Movies.Queries.GetAll;
public record GetAllMoviesQuery() : IRequest<ICollection<MovieResponse>>;
