using MediatR;
using Movies.Domain.Aggregates.Genres;

namespace Movies.Application.Features.Genres.Queries.GetAll;
public record GetAllGenresQuery() : IRequest<List<Genre>>;
