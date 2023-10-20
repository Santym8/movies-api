using System.Net;

namespace Movies.api.Exceptions.User;
public class BadCredentials : Exception, IApiException
{
    public string ErrorMessage => "Bad credentials";

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}