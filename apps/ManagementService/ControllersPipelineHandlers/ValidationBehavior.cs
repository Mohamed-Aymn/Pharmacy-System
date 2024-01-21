using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace ManagementService.ControllersPipelineHandlers;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
  private readonly IValidator<TRequest>? _validator;

  public ValidationBehavior(IValidator<TRequest>? validator)
  {
    _validator = validator;
  }

  public async Task<TResponse> Handle(
      TRequest request,
      RequestHandlerDelegate<TResponse> next,
      CancellationToken cancellationToken)
  {
    if (_validator is null)
    {
      return await next();
    }

    ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

    return !validationResult.IsValid
        ? throw new ValidationException(validationResult.Errors)
        : await next();
  }
}