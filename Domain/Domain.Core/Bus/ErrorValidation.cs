using System.Net;

namespace Domain.Core.Bus;

public class ErrorValidation
{
    public HttpStatusCode ErrorCode { get; }
    public string Message { get; }

    public ErrorValidation(HttpStatusCode errorCode, string message)
    {
        ErrorCode = errorCode;
        Message = message;
    }
}