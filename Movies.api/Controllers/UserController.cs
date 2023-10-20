using Microsoft.AspNetCore.Mvc;
using Movies.api.Auth;
using Movies.api.Dto;
using Movies.api.Services;

namespace Movies.api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Create([FromBody] RegisterRequest request)
    {
        _userService.Create(request.Username, request.Password);
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_userService.GetAll());
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public IActionResult Authenticate([FromBody] RegisterRequest request)
    {
        var token = _userService.Authenticate(request.Username, request.Password);
        return Ok(new { token });
    }

}