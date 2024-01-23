using ManagementService.Contracts.Medicine.Create;
using ManagementService.Contracts.Medicine.Get;
using ManagementService.Contracts.Medicine.Update;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.Controllers;

[ApiController]
[Route("[controller]s")]
public class MedicineController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public MedicineController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }

  [HttpGet(Name = "GetMedicinees")]
  public async Task<IEnumerable<GetMedicinesResponse>> Get(CancellationToken cancellationToken)
  {
    return await _mediator.Send(new GetMedicinesRequest(), cancellationToken);
  }

  [HttpPost(Name = "CreateMedicine")]
  public async Task<IActionResult> Create(CreateMedicineRequest request, CancellationToken cancellationToken)
  {
    var createMedicineDTO = _mapper.Map<CreateMedicineDTO>(request);

    var result = await _mediator.Send(createMedicineDTO, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPut(Name = "CreateMedicine")]
  public async Task<IActionResult> Put(UpdateMedicineRequest request, CancellationToken cancellationToken)
  {
    var updateMedicineDTO = _mapper.Map<UpdateMedicineDTO>(request);

    var result = await _mediator.Send(updateMedicineDTO, cancellationToken);

    return Ok(result.Message);
  }
}
