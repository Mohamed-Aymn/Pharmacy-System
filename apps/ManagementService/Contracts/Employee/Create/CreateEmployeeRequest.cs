using ManagementService.Types;

namespace ManagementService.Contracts.Employee.Create;

public record CreateEmployeeRequest(
    string Name,
    string PhoneNumber,
    string Email,
    EmployeeRole Role,
    string BranchName
);
