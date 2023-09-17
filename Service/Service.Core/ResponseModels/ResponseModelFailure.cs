using System.Net;
using Domain.Core.Bus;

namespace Service.Core.ResponseModels;

public class ResponseModelFailure
{
    public IEnumerable<ErrorValidation> ValidationErrors { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ResponseModelFailure(IEnumerable<ErrorValidation> validationErrors, HttpStatusCode statusCode)
    {
        ValidationErrors = validationErrors;
        StatusCode = statusCode;
    }
}