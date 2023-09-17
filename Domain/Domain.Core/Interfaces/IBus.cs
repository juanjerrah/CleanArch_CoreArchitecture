using System.Net;
using Domain.Core.Bus;

namespace Domain.Core.Interfaces;

public interface IBus
{
    bool HasValidationErrors();
    IList<ErrorValidation> GetValidationErrors();
    void RaiseValidationError(HttpStatusCode errorCode, string message);
}