using MediatR;
using Movies.Application.Dtos.Genre.Responses;

namespace Movies.Application.Features.Genres.Queries.GetAll;
public record GetAllGenresQuery() : IRequest<ICollection<GenreResponse>>;
