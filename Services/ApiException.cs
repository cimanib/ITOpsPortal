using System.Net;

namespace ITOpsPortal.Services;

public class ApiException(string message, HttpStatusCode? status = null, Exception? inner = null) : Exception(message, inner)
{
    public HttpStatusCode? Status { get; } = status;
}
