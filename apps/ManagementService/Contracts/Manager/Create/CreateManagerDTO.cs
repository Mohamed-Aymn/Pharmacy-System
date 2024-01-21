using MediatR;

namespace ManagementService.Contracts.Manager.Create;

public record CreateManagerDTO(
    string Name,
    string PhoneNumber,
    string Email
) : IRequest<CreateManagerResponse>;
