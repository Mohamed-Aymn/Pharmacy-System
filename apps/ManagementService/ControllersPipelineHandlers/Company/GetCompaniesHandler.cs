using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Companies.Get;

namespace ManagementService.ControllersPipelineHandlers.Companies;

public class GetCompaniesHandler : IRequestHandler<GetCompaniesRequest, IEnumerable<GetCompaniesResponse>>
{
  private readonly IRepository<Models.Company, string> _companyRepository;
  private readonly IMapper _mapper;
  public GetCompaniesHandler(IRepository<Models.Company, string> companyRepository, IMapper mapper)
  {
    _mapper = mapper;
    _companyRepository = companyRepository;
  }

  public async Task<IEnumerable<GetCompaniesResponse>> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
  {
    var companies = await _companyRepository.GetAllAsync();
    return companies.Select(manager => _mapper.Map<GetCompaniesResponse>(companies));
  }
}