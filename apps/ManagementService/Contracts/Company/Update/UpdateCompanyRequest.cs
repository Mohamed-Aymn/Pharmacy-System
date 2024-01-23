namespace ManagementService.Contracts.Company.Update;

public record UpdateCompanyRequest(
    string Name,
    string PhoneNumber,
    string Email,
    int[] PaymentShares
);
