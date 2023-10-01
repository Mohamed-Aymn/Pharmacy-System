using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.Controllers;

public class ErrorsController : Controller
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(
            statusCode: HttpContext.Response.StatusCode,
            title: exception?.Message);
    }
}