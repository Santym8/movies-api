using Microsoft.AspNetCore.Mvc;
using Movies.api.Dto;
using Movies.api.Services;

namespace Movies.api.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectorController : ControllerBase
{
    private readonly IDirectorService _directorService;

    public DirectorController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpPost]
    public IActionResult CreateDirector([FromBody] DirectorRequest director)
    {
        _directorService.CreateDirector(director);
        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetDirectorById(int id)
    {
        var director = _directorService.GetDirectorById(id);
        return Ok(director);
    }


}