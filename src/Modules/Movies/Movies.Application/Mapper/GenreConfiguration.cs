using Mapster;
using Movies.Application.Dtos.Genre.Requests;
using Movies.Application.Dtos.Genre.Responses;
using Movies.Application.Features.Genres.Commands.Create;
using Movies.Application.Features.Genres.Commands.Update;
using Movies.Domain.Aggregates.Genres;

namespace Movies.Application.Mapper;
internal class GenreConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateGenreRequest, CreateGenreCommand>();

        config.NewConfig<(Guid genreId, UpdateGenreRequest request), UpdateGenreCommand>()
            .Map(dest => dest.GenreId, src => src.genreId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Genre, GenreResponse>()
            .Map(dest => dest.Id, src => src.Id);
    }
}
