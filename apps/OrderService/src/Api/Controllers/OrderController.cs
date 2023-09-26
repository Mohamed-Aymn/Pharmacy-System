using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts;

namespace OrderService.Controllers;

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
        // CreateOrderCommandValidator validator = new();
        // ValidationResult results = validator.Validate(request);
        // if (!results.IsValid)
        // {
        //     throw new Exception("something went wrong");
        // }
    }
}