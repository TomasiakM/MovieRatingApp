namespace Movies.Application.Dtos.Movies.Requests;
public record CreateMovieRequest(
    string Title,
    string Description,
    string Image);
