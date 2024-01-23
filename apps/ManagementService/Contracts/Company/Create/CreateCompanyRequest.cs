namespace ManagementService.Contracts.Company.Create;

public record CreateCompanyRequest(
    string Name,
    string PhoneNumber,
    string Email,
    int[] PaymentShares 
);
