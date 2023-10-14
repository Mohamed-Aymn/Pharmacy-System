using Microsoft.AspNetCore.Mvc;
using MediatR;
using OrderService.Application.Order.Commands.Create;
using MapsterMapper;

namespace OrderService.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public OrderController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        // create command
        CreateOrderCommand command = _mapper.Map<CreateOrderCommand>(request);

        // send to mediator order creation pipline
        await _mediator.Send(command, cancellationToken);
        // var orderResult = await _mediator.Send(command, cancellationToken);

        // return Ok or Problem
        return Ok("Order created successfully");
    }
}