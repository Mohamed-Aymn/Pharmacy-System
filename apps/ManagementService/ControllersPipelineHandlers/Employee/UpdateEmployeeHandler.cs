using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Employee.Update;

namespace ManagementService.ControllersPipelineHandlers.Employee;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeDTO, UpdateEmployeeResponse>
{
  private readonly IRepository<Models.Employee, string> _employeeRepository;
  public UpdateEmployeeHandler(IRepository<Models.Employee, string> employeeRepository)
  {
    _employeeRepository = employeeRepository;
  }

  public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeDTO request, CancellationToken cancellationToken)
  {
    var existingEmployee = await _employeeRepository.GetByIdAsync(request.Name);

    if (existingEmployee is null)
    {
      throw new Exception();
    }

    existingEmployee.PhoneNumber = request.PhoneNumber;
    existingEmployee.Email = request.Email;
    _employeeRepository.Update(existingEmployee);
    await _employeeRepository.SaveChangesAsync();

    return new UpdateEmployeeResponse(existingEmployee.Name);
  }
}