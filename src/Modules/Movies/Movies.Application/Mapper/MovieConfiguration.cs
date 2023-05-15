using Mapster;
using Movies.Application.Dtos.Movies.Requests;
using Movies.Application.Dtos.Movies.Responses;
using Movies.Application.Features.Movies.Commands.Create;
using Movies.Application.Features.Movies.Commands.Update;
using Movies.Domain.Aggregates.Genres;
using Movies.Domain.Aggregates.Movies;

namespace Movies.Application.Mapper;
internal class MovieConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMovieRequest, CreateMovieCommand>();

        config.NewConfig<(Guid movieId, UpdateMovieRequest request), UpdateMovieCommand>()
            .Map(dest => dest.MovieId, src => src.movieId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<(Movie movie, Genre genre), MovieResponse>()
            .Map(dest => dest.Genre, src => src.genre)
            .Map(dest => dest.Id, src => src.movie.Id)
            .Map(dest => dest, src => src.movie);
    }
}
