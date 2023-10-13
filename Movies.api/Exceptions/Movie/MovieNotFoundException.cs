using System.Net;

namespace Movies.api.Exceptions.Movie;
public class MovieNotFoundException : Exception, IApiException
{
    public string ErrorMessage => "Movie not found";

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}