using Microsoft.AspNetCore.Mvc;
using MediatR;
using MapsterMapper;
using PharmacyService.Contracts.Receipt;
using PharmacyService.Application.Receipts.CreateReceipt;
using PharmacyService.Application.Receipts.ReturnReceipt;

namespace PharmacyService.Api.Controllers;

[ApiController]
[Route("[Controller]s")]
public class ReceiptController : Controller
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public ReceiptController(IMediator mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("CreateReceipt", Name = "CreateReceipt")]
  public async Task<IActionResult> CreateOrder(CreateReceiptRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<CreateReceiptDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("ReturnReceipt", Name = "ReturnReceipt")]
  public async Task<IActionResult> CreateOrder(ReturnReceiptRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<ReturnReceiptDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }
}