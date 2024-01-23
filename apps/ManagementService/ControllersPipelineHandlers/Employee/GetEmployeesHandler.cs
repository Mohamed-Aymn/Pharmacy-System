using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Employee.Get;

namespace ManagementService.ControllersPipelineHandlers.Employee;

public class GetEmployeeHandler : IRequestHandler<GetEmployeesRequest, IEnumerable<GetEmployeesResponse>>
{
  private readonly IRepository<Models.Employee, string> _employeeRepository;
  private readonly IMapper _mapper;
  public GetEmployeeHandler(IRepository<Models.Employee, string> employeeRepository, IMapper mapper)
  {
    _mapper = mapper;
    _employeeRepository = employeeRepository;
  }

  public async Task<IEnumerable<GetEmployeesResponse>> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
  {
    var employees = await _employeeRepository.GetAllAsync();
    return employees.Select(employee => _mapper.Map<GetEmployeesResponse>(employee));
  }
}