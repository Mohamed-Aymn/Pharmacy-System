using MediatR;

namespace ManagementService.Contracts.Company.Update;

public record UpdateCompanyDTO(
    string Name,
    string PhoneNumber,
    string Email,
    int[] PaymentShares
) : IRequest<UpdateCompanyResponse>;
