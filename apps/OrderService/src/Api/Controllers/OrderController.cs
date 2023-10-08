using FluentValidation.Results;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Exceptions;
using OrderService.Application.Order.Commands.CreateOrder;
using OrderService.Contracts;
using OrderService.Contracts.Order;
using OrderNamespace = OrderService.Domain.Order;
using OrderService.Domain.Order.Entites;
using OrderService.Domain.Order.ValueObjects;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    private readonly OrderServiceDbContext _dbContext;
    public OrderController(OrderServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        // request validation
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

        // create command
        // mapping betten order reqeust and order command
        CreateOrderCommand createOrderCommand = request.Adapt<CreateOrderCommand>();
        // list, tracking id, order items and order status are still empty
        // create mock orderItem
        // validate command
        CreateOrderCommandValidator commandValidator = new();
        ValidationResult commandValidatorResults = commandValidator.Validate(createOrderCommand);
        if (!commandValidatorResults.IsValid)
        {
            throw new Exception("something went wrong");
        }

        // store it in database
        try
        {
            // OrderNamespace.Order order = createOrderCommand.Adapt<OrderNamespace.Order>();
            OrderId orderId = new(Guid.NewGuid());
            OrderNamespace.Order order = new(orderId);
            await _dbContext.Order.AddAsync(order);
            var test = order;
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
            return Problem();
        }

        // response
        return Ok("Order created successfully");
    }
}