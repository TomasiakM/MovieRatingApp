using Mapster;
using Movies.Application.Dtos.Movies.Requests;
using Movies.Application.Features.Movies.Commands.Create;
using Movies.Application.Features.Movies.Commands.Update;

namespace Movies.Application.Mapper;
internal class MovieConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMovieRequest, CreateMovieCommand>();

        config.NewConfig<(Guid movieId, UpdateMovieRequest request), UpdateMovieCommand>()
            .Map(dest => dest.MovieId, src => src.movieId)
            .Map(dest => dest, src => src.request);
    }
}
