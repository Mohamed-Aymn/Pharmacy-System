using ManagementService.Types;
using MediatR;

namespace ManagementService.Contracts.Employee.Update;

public record UpdateEmployeeDTO(
    string Name,
    string PhoneNumber,
    string Email,
    EmployeeRole Role,
    string BranchName
) : IRequest<UpdateEmployeeResponse>;
