using System.Net;
using Domain.Core.Interfaces;

namespace Domain.Core.Bus;

public class Bus : IBus
{
    private IList<ErrorValidation>? ErrorValidations { get; set; }
    public bool HasValidationErrors()
    {
        return GetValidationErrors().Any();
    }

    public IList<ErrorValidation> GetValidationErrors()
    {
        ErrorValidations ??= new List<ErrorValidation>();
        return ErrorValidations;
    }

    public void RaiseValidationError(HttpStatusCode errorCode, string message)
    {
        ErrorValidations ??= new List<ErrorValidation>();
        ErrorValidations.Add(new ErrorValidation(errorCode, message));
        Console.WriteLine(message);
    }
}