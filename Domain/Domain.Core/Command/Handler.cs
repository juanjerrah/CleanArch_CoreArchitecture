using System.Net;
using Domain.Core.Interfaces;
using FluentValidation.Results;

namespace Domain.Core.Command;

public class Handler
{
    private readonly IBus _bus;

    public Handler(IBus bus)
    {
        _bus = bus;
    }
    
    public void NotifyValidationErrors(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
            _bus.RaiseValidationError(HttpStatusCode.BadRequest, error.ErrorMessage);
    }
    
    protected void NotifyValidationErrors(string error)
    {
        _bus.RaiseValidationError(HttpStatusCode.BadRequest, error);
    }
    
    public bool HasValidationErrors()
    {
        return _bus.HasValidationErrors();
    }
    
    
}