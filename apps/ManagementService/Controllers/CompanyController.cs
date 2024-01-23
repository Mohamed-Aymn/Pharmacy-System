using ManagementService.Contracts.Company.Create;
using ManagementService.Contracts.Company.Get;
using ManagementService.Contracts.Company.Update;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.Controllers;

[ApiController]
[Route("[controller]s")]
public class CompanyController : ControllerBase
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  public CompanyController(IMapper mapper, IMediator mediator)
  {
    _mapper = mapper;
    _mediator = mediator;
  }

  [HttpGet(Name = "GetCompanyes")]
  public async Task<IEnumerable<GetCompaniesResponse>> Get(CancellationToken cancellationToken)
  {
    return await _mediator.Send(new GetCompaniesRequest(), cancellationToken);
  }

  [HttpPost(Name = "CreateCompany")]
  public async Task<IActionResult> Create(CreateCompanyRequest request, CancellationToken cancellationToken)
  {
    var createCompanyDTO = _mapper.Map<CreateCompanyDTO>(request);

    var result = await _mediator.Send(createCompanyDTO, cancellationToken);

    return Ok(result.Message);
  }

  [HttpPut(Name = "CreateCompany")]
  public async Task<IActionResult> Put(UpdateCompanyRequest request, CancellationToken cancellationToken)
  {
    var updateCompanyDTO = _mapper.Map<UpdateCompanyDTO>(request);

    var result = await _mediator.Send(updateCompanyDTO, cancellationToken);

    return Ok(result.Message);
  }
}
