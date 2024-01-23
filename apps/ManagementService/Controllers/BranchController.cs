using ManagementService.Contracts.Branch.Create;
using ManagementService.Contracts.Branch.Get;
using ManagementService.Contracts.Branch.Update;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.Controllers;

[ApiController]
[Route("[controller]s")]
public class BranchController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public BranchController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }

  [HttpGet(Name = "GetBranches")]
  public async Task<IEnumerable<GetBranchResponse>> Get(CancellationToken cancellationToken)
  {
    return await _mediator.Send(new GetBranchesRequest(), cancellationToken);
  }

  [HttpPost(Name = "CreateBranch")]
  public async Task<IActionResult> Create(CreateBranchRequest request, CancellationToken cancellationToken)
  {
    var createBranchDTO = _mapper.Map<CreateBranchDTO>(request);

    var result = await _mediator.Send(createBranchDTO, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPut(Name = "CreateBranch")]
  public async Task<IActionResult> Put(UpdateBranchRequest request, CancellationToken cancellationToken)
  {
    var updateBranchDTO = _mapper.Map<UpdateBranchDTO>(request);

    var result = await _mediator.Send(updateBranchDTO, cancellationToken);

    return Ok(result.Message);
  }
}
