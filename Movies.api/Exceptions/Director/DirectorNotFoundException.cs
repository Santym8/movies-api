using System.Net;

namespace Movies.api.Exceptions.Director;
public class DirectorNotFoundException : Exception, IApiException
{
    public string ErrorMessage => "Director not found.";

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}