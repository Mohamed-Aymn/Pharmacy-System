using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Company.Create;

namespace ManagementService.ControllersPipelineHandlers.Company;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyDTO, CreateCompanyResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Company, string> _companyRepository;
  public CreateCompanyHandler(IMapper mapper, IRepository<Models.Company, string> companyRepository)
  {
    _mapper = mapper;
    _companyRepository = companyRepository;
  }

  public Task<CreateCompanyResponse> Handle(CreateCompanyDTO createCompanyDTO, CancellationToken cancellationToken)
  {
    Models.Company company = new(
        createCompanyDTO.Name,
        createCompanyDTO.PhoneNumber,
        createCompanyDTO.Email,
        createCompanyDTO.PaymentShares);
    _companyRepository.Add(company);
    _companyRepository.SaveChangesAsync();

    return Task.FromResult(new CreateCompanyResponse(company.Name));
  }
}