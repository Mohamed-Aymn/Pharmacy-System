namespace ManagementService.Contracts.Employee.Get;

public record GetEmployeesResponse(
  string Name,
  string Email,
  string PhoneNumber
);
