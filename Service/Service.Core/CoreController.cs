using System.Net;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Core.ResponseModels;

namespace Service.Core;

public class CoreController : ControllerBase
{
    private readonly IBus _bus;

    public CoreController(IBus bus) => _bus = bus;

    public new IActionResult Response(object result = null)
    {
        return Response<object>(result);
    }

    private new IActionResult Response<T>(T data)
    {
        var hasErrors = _bus.HasValidationErrors();

        if (!hasErrors)
            return Ok(new ReturnJsonContent<T>(data, HttpStatusCode.OK, true));

        var errors = _bus.GetValidationErrors();
        
        return BadRequest(new ReturnJsonContent<T>(data, HttpStatusCode.BadRequest, false, errors));
    }
    
}