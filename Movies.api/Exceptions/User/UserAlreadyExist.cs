using System.Net;

namespace Movies.api.Exceptions.User;
public class UserAlreadyExist : Exception, IApiException
{
    public string ErrorMessage => "Username already exists";

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}