using MediatR;

namespace ManagementService.Contracts.Manager.Create;

public record CreateManagerDTO(
    string Name,
    int PhoneNumber,
    string Email
) : IRequest<CreateManagerResponse>;
