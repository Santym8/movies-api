using System.Net;

namespace Movies.api.Exceptions.User;
public class UserNotFound : Exception, IApiException
{
    public string ErrorMessage => "User not found";

    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}