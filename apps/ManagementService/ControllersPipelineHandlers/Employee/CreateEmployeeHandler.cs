using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Employee.Create;
using ManagementService.MessageBroker;
using SharedKernel.Events;

namespace ManagementService.ControllersPipelineHandlers.Employee;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeDTO, CreateEmployeeResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Employee, string> _employeeRepository;
  private readonly IRepository<Models.Branch, string> _branchRepository;

  private readonly IEventBus _eventBus;
  public CreateEmployeeHandler(IMapper mapper, IRepository<Models.Employee, string> employeeRepository, IRepository<Models.Branch, string> branchRepository, IEventBus eventBus)
  {
    _mapper = mapper;
    _employeeRepository = employeeRepository;
    _branchRepository = branchRepository;
    _eventBus = eventBus;
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

    await _eventBus.PublishAsync(new UserCreatedEvent(createEmployeeDTO.Name, "bla", createEmployeeDTO.Email), cancellationToken);

    return await Task.FromResult(new CreateEmployeeResponse(employee.Name));
  }
}