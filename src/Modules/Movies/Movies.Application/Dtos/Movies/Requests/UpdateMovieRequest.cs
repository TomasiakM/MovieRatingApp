namespace Movies.Application.Dtos.Movies.Requests;
public record UpdateMovieRequest(
    string Title,
    string Description,
    string Image,
    string Premiere,
    string GenreId);
