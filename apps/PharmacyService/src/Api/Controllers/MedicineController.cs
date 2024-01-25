using Microsoft.AspNetCore.Mvc;
using MediatR;
using MapsterMapper;
using PharmacyService.Contracts.Medicine;
using PharmacyService.Application.Medicines.Create;
using PharmacyService.Application.Medicines.Search;
using BranchService.Application.Medicines.DirectSearch;
using PharmacyService.Application.Medicines.BranchesSearch;
using PharmacyService.Application.Medicines.SendBranchTransfer;
using PharmacyService.Application.Medicines.ReceiveBranchTransfer;

namespace PharmacyService.Api.Controllers;

[ApiController]
[Route("[Controller]s")]
public class MedicineController : Controller
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public MedicineController(IMediator mediator, IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("Dispense", Name = "DispenseMedicines")]
  public async Task<IActionResult> CreateOrder(DispsneRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<DispenseMedicineDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("Search", Name = "MedicinesSearch")]
  public async Task<IActionResult> CreateOrder(SearchRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<SearchDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("DirectSearch", Name = "DirectBarCodeSearch")]
  public async Task<IActionResult> CreateOrder(DirectSearchRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<DirectSearchDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("BranchesSearch", Name = "MultipleBranchesSearch")]
  public async Task<IActionResult> CreateOrder(BranchesSearchRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<BranchesSearchDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("SendBranchTransfer", Name = "MultipleBranchesSearch")]
  public async Task<IActionResult> CreateOrder(SendBranchTransferRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<SendBranchTransferDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPost("ReceiveBranchTransfer", Name = "MultipleBranchesSearch")]
  public async Task<IActionResult> CreateOrder(ReceiveBranchTransferRequest request, CancellationToken cancellationToken)
  {
    var command = _mapper.Map<ReceiveBranchTransferDto>(request);

    var result = await _mediator.Send(command, cancellationToken);

    return Ok(result.Message);
  }
}