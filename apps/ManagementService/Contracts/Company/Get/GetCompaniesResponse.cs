namespace ManagementService.Contracts.Company.Get;

public record GetCompaniesResponse(
  string Name,
  string Email,
  string PhoneNumber,
  int[] PaymentShares
);
