using MediatR;

namespace ManagementService.Contracts.Company.Create;

public record CreateCompanyDTO(
    string Name,
    string PhoneNumber,
    string Email,
    int[] PaymentShares
) : IRequest<CreateCompanyResponse>;
