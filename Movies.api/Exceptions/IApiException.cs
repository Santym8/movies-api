using System.Net;

namespace Movies.api.Exceptions;
public interface IApiException
{
    public string ErrorMessage { get; }
    public HttpStatusCode StatusCode { get; }
}