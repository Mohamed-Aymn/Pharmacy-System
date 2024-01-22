namespace ManagementService.Contracts.Manager.Get;

public record GetManagerResponse(
  string Name,
  string Email,
  string PhoneNumber
);
