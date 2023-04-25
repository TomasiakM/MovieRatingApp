using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;
using Movies.Domain.Aggregates.Genres.ValueObjects;

namespace Movies.Application.Features.Genres.Commands.Update;
internal class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var genreId = new GenreId(request.GenreId);
        var genre = await _unitOfWork.Genres.GetAsync(genreId);

        if (genre is null)
        {
            throw new NotFoundException();
        }

        genre.Update(request.Name);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
