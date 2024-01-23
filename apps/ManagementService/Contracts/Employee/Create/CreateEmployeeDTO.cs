using ManagementService.Types;
using MediatR;

namespace ManagementService.Contracts.Employee.Create;

public record CreateEmployeeDTO(
    string Name,
    string PhoneNumber,
    string Email,
    EmployeeRole Role,
    string BranchName
) : IRequest<CreateEmployeeResponse>;
