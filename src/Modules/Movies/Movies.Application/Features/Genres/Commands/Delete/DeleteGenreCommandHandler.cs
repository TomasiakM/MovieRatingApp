using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;

namespace Movies.Application.Features.Genres.Commands.Delete;
internal class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _unitOfWork.Genres.GetAsync(request.GenreId);

        if (genre is null)
        {
            throw new NotFoundException();
        }

        _unitOfWork.Genres.Delete(genre);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
