using Common.Domain.Exceptions;
using MediatR;
using Movies.Application.Interfaces;

namespace Movies.Application.Features.Movies.Commands.Update;
internal class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMovieCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _unitOfWork.Movies.GetAsync(request.MovieId);

        if (movie is null)
        {
            throw new NotFoundException();
        }

        movie.Update(
            request.Title,
            request.Description,
            request.Image,
            DateOnly.Parse(request.Premiere),
            new Guid(request.GenreId));

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
