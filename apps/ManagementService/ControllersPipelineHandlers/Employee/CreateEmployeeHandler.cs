using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Employee.Create;

namespace ManagementService.ControllersPipelineHandlers.Employee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeDTO, CreateEmployeeResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Employee, string> _employeeRepository;
  public CreateEmployeeHandler(IMapper mapper, IRepository<Models.Employee, string> employeeRepository)
  {
    _mapper = mapper;
    _employeeRepository = employeeRepository;
  }

  public Task<CreateEmployeeResponse> Handle(CreateEmployeeDTO createEmployeeDTO, CancellationToken cancellationToken)
  {
    Models.Employee employee = new(
        createEmployeeDTO.Name,
        createEmployeeDTO.PhoneNumber,
        createEmployeeDTO.Email,
        createEmployeeDTO.Role,
        createEmployeeDTO.BranchName);
    _employeeRepository.Add(employee);
    _employeeRepository.SaveChangesAsync();

    return Task.FromResult(new CreateEmployeeResponse(employee.Name));
  }
}