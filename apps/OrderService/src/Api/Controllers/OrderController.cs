using Mapster;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts;
using MediatR;
using OrderService.Application.Order.Commands.Create;
using OrderService.Infrastructure.Persistence;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    private readonly OrderServiceDbContext _dbContext;
    public OrderController(OrderServiceDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        // create command
        CreateOrderCommand command = request.Adapt<CreateOrderCommand>();

        // send to mediator order creation pipline
        var orderResult = await _mediator.Send(command);

        // return Ok or Problem
        return Ok("Order created successfully");
    }
}