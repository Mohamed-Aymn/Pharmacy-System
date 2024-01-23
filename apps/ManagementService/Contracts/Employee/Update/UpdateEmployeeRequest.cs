using ManagementService.Types;

namespace ManagementService.Contracts.Employee.Update;

public record UpdateEmployeeRequest(
    string Name,
    string PhoneNumber,
    string Email,
    EmployeeRole Role,
    string BranchName
);
