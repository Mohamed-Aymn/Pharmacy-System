using OrderService.Application.Exceptions;

namespace OrderService.Api.Middlwares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = 500;
        if (exception is ModelValidationException)
        {
            statusCode = 403;
        }

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(exception.Message);
    }
}