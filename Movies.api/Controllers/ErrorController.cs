using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.api.Exceptions;
using Movies.api.Exceptions.Movie;

namespace Movies.api.Controllers;
[ApiController]
public class ErrorController : ControllerBase
{

    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IApiException ex => ((int)ex.StatusCode, ex.ErrorMessage),
            _ => (500, "Internal Server Error")
        };
        return Problem(
            statusCode: statusCode,
            title: message
        );
    }
}