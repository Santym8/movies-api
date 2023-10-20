using Microsoft.AspNetCore.Mvc;
using Movies.api.Auth;
using Movies.api.Dto;
using Movies.api.Services;

namespace Movies.api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MoviesController : ControllerBase
{

    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(_movieService.GetMovies());
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieByID(int id)
    {
        var movie = _movieService.GetMovieById(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] MovieRequest movie)
    {
        _movieService.AddMovie(movie);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        _movieService.DeleteMovie(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] MovieRequest movie)
    {
        _movieService.UpdateMovie(id, movie);
        return NoContent();
    }

}