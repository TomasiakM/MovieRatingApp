using MediatR;

namespace Movies.Application.Features.Movies.Commands.Create;
public record CreateMovieCommand(
    string Title,
    string Description,
    string Image,
    string Premiere,
    string MovieGenreId) : IRequest;
