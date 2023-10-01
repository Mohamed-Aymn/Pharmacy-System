using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Exceptions;
using OrderService.Contracts;
using OrderService.Contracts.Order;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    public OrderController()
    {
    }

    [HttpPost]
    public async Task CreateOrder(CreateOrderRequest request)
    {
        CreateOrderRequestValidatior validator = new();
        ValidationResult results = validator.Validate(request);
        if (!results.IsValid)
        {
            List<ModelValidationException.ModelAttributesErrors> errorList = new();
            foreach (var failure in results.Errors)
            {
                errorList.Add(new ModelValidationException.ModelAttributesErrors(
                    message: failure.ErrorMessage,
                    field: failure.PropertyName
                ));
            }
            throw new ModelValidationException(errorList);
        }
    }
}