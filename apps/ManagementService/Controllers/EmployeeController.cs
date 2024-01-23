using System.ComponentModel.DataAnnotations;
using ManagementService.Contracts.Employee.Create;
using ManagementService.Contracts.Employee.Get;
using ManagementService.Contracts.Employee.Update;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.Controllers;

[ApiController]
[Route("[controller]s")]
public class EmployeeController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public EmployeeController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }

  [HttpGet(Name = "GetEmployees")]
  public async Task<IEnumerable<GetEmployeesResponse>> Get(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetEmployeesRequest(), cancellationToken);

    return result;
  }

  [HttpPost(Name = "CreateEmployee")]
  public async Task<IActionResult> Create(CreateEmployeeRequest request, CancellationToken cancellationToken)
  {
    var createEmployeeDTO = _mapper.Map<CreateEmployeeDTO>(request);

    var result = await _mediator.Send(createEmployeeDTO, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPut(Name = "CreateEmployee")]
  public async Task<IActionResult> Put(UpdateEmployeeRequest request, CancellationToken cancellationToken)
  {
    var updateEmployeeDTO = _mapper.Map<UpdateEmployeeDTO>(request);

    var result = await _mediator.Send(updateEmployeeDTO, cancellationToken);

    return Ok(result.Message);
  }
}
