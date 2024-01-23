using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Company.Update;

namespace ManagementService.ControllersPipelineHandlers.Company;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyDTO, UpdateCompanyResponse>
{
  private readonly IRepository<Models.Company, string> _CompanyRepository;
  public UpdateCompanyHandler(IRepository<Models.Company, string> CompanyRepository)
  {
    _CompanyRepository = CompanyRepository;
  }

  public async Task<UpdateCompanyResponse> Handle(UpdateCompanyDTO request, CancellationToken cancellationToken)
  {
    var existingCompany = await _CompanyRepository.GetByIdAsync(request.Name);

    if (existingCompany is not null)
    {
      existingCompany.PhoneNumber = request.PhoneNumber;
      existingCompany.Email = request.Email;
      _CompanyRepository.Update(existingCompany);
      await _CompanyRepository.SaveChangesAsync();
    }

    return new UpdateCompanyResponse(existingCompany.Name);
  }
}