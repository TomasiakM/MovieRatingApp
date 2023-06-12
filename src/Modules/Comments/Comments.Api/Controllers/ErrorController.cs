﻿using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Comments.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        int statusCode = StatusCodes.Status500InternalServerError;
        string message = "Coś poszło nie tak";
        switch (ex) 
        {
            case UnauthorizedException _:
                statusCode = StatusCodes.Status401Unauthorized; 
                break;
            case ForbiddenException _:
                statusCode = StatusCodes.Status403Forbidden;
                message = "Brak dostępu do zasobu";
                break;
            case NotFoundException _:
                statusCode = StatusCodes.Status404NotFound;
                message = "Nie odnaleziono zasobu";
                break;
            case DomainException de:
                message = de.Message;
                break;
        }

        Console.WriteLine("[ERROR]: XDDDDD");
        Console.WriteLine(message);

        return Problem(statusCode: statusCode, detail: message);
    }
}
