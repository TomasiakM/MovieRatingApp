using Movies.Application.Dtos.Genre.Responses;

namespace Movies.Application.Dtos.Movies.Responses;
public record MovieResponse(
    string Id,
    string Title,
    string Description,
    string Image,
    string Premiere,
    GenreResponse Genre);
