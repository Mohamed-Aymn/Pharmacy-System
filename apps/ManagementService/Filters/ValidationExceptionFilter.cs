using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

public class ValidationExceptionFilter : IExceptionFilter
{
  public void OnException(ExceptionContext context)
  {
    if (context.Exception is FluentValidation.ValidationException validationException)
    {
      var validationProblemDetails = new ValidationProblemDetails
      {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        Title = "Validation Failed",
        Status = 400,
      };
      validationProblemDetails.Extensions["traceId"] = Guid.NewGuid();


      foreach (var error in validationException.Errors)
      {
        var fieldKey = string.IsNullOrEmpty(error.PropertyName) ? "" : char.ToLower(error.PropertyName[0]) + error.PropertyName.Substring(1);

        if (validationProblemDetails.Errors.ContainsKey(fieldKey))
        {
          var existingErrors = validationProblemDetails.Errors[fieldKey];
          var newErrors = existingErrors.Concat(new[] { error.ErrorMessage });
          validationProblemDetails.Errors[fieldKey] = newErrors.ToArray();
        }
        else
        {
          validationProblemDetails.Errors[fieldKey] = new[] { error.ErrorMessage };
        }
      }

      context.Result = new ObjectResult(validationProblemDetails)
      {
        StatusCode = validationProblemDetails.Status,
        ContentTypes = { "application/problem+json" },
      };

      context.ExceptionHandled = true;
    }
  }
}
