using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Dtos.Movies.Requests;
using Movies.Application.Features.Movies.Commands.Create;
using Movies.Application.Features.Movies.Commands.Delete;
using Movies.Application.Features.Movies.Commands.Update;
using Movies.Application.Features.Movies.Queries.GetAll;
using Movies.Application.Features.Movies.Queries.GetById;

namespace Movies.Api.Controllers;

[ApiController]
[Route("/api/movie")]
public class MovieController : ControllerBase
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public MovieController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllMoviesQuery();
        var movies = await _mediatr.Send(query);

        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    public async Task<IActionResult> GetById(Guid movieId)
    {
        var query = new GetMovieByIdQuery(movieId);
        var movie = await _mediatr.Send(query);

        return Ok(movie);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(CreateMovieRequest request)
    {
        var command = _mapper.Map<CreateMovieCommand>(request);
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpPut("{movieId}")]
    public async Task<IActionResult> Update(Guid movieId, UpdateMovieRequest request)
    {
        var command = _mapper.Map<UpdateMovieCommand>((movieId, request));
        await _mediatr.Send(command);

        return NoContent();
    }

    [HttpDelete("{movieId}")]
    public async Task<IActionResult> Delete(Guid movieId)
    {
        var command = new DeleteMovieCommand(movieId);
        await _mediatr.Send(command);

        return NoContent();
    }
}
