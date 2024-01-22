using ManagementService.Contracts.Manager.Create;
using ManagementService.Contracts.Manager.Get;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagerController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public ManagerController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }

  [HttpGet(Name = "GetManagers")]
  public async Task<IEnumerable<GetManagerResponse>> Get(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetManagerRequest(), cancellationToken);

    return result;
  }

  [HttpPost(Name = "CreateManager")]
  public async Task<IActionResult> Create(CreateManagerRequest request, CancellationToken cancellationToken)
  {
    var createManagerDTO = _mapper.Map<CreateManagerDTO>(request);

    // var result = await _mediator.Send(createManagerDTO, cancellationToken);
    var result = await _mediator.Send(createManagerDTO, cancellationToken);

    return Ok(result.Message);
  }
}
