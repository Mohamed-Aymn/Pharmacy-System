using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Employee.Create;

namespace ManagementService.ControllersPipelineHandlers.Employee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeDTO, CreateEmployeeResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Employee, string> _employeeRepository;
  private readonly IRepository<Models.Branch, string> _branchRepository;
  public CreateEmployeeHandler(IMapper mapper, IRepository<Models.Employee, string> employeeRepository, IRepository<Models.Branch, string> branchRepository)
  {
    _mapper = mapper;
    _employeeRepository = employeeRepository;
    _branchRepository = branchRepository;
  }

  public async Task<CreateEmployeeResponse> Handle(CreateEmployeeDTO createEmployeeDTO, CancellationToken cancellationToken)
  {
    var branch = await _branchRepository.GetByIdAsync(createEmployeeDTO.BranchName);

    if (branch is null)
    {
      throw new Exception();
    }

    Models.Employee employee = new(
        createEmployeeDTO.Name,
        createEmployeeDTO.PhoneNumber,
        createEmployeeDTO.Email,
        createEmployeeDTO.Role,
        createEmployeeDTO.BranchName);
    _employeeRepository.Add(employee);

    await _employeeRepository.SaveChangesAsync();

    return await Task.FromResult(new CreateEmployeeResponse(employee.Name));
  }
}