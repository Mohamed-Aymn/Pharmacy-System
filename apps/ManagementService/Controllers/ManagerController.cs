using ManagementService.Contracts.Manager.Create;
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

  // [HttpGet(Name = "GetManagers")]
  // public IEnumerable<Manager> Get()
  // {

  // }

  [HttpPost(Name = "CreateManager")]
  public async Task<IActionResult> Create(CreateManagerRequest request, CancellationToken cancellationToken)
  {
    var createManagerData = _mapper.Map<CreateManagerDTO>(request);

    var result = await _mediator.Send(createManagerData, cancellationToken);

    return Ok(result.Message);
  }
}
