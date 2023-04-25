using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dtos.Genre.Requests;
using Movies.Application.Features.Genres.Commands.Create;
using Movies.Application.Features.Genres.Commands.Delete;
using Movies.Application.Features.Genres.Commands.Update;
using Movies.Application.Features.Genres.Queries.GetAll;

namespace Movies.Api.Controllers;

[ApiController]
[Route("/api/genre")]
public class GenreController : ControllerBase
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public GenreController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllGenresQuery();
        var genres = await _mediatr.Send(query);

        return Ok(genres);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGenreRequest request)
    {
        var command = _mapper.Map<CreateGenreCommand>(request);
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpPut("{genreId}")]
    public async Task<IActionResult> Update(Guid genreId, UpdateGenreRequest request)
    {
        var command = _mapper.Map<UpdateGenreCommand>((genreId, request));
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpDelete("{genreId}")]
    public async Task<IActionResult> Delete(Guid genreId)
    {
        var command = new DeleteGenreCommand(genreId);
        await _mediatr.Send(command);

        return NoContent();
    }
}
