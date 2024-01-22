using MediatR;

namespace ManagementService.Contracts.Manager.Update;

public record UpdateManagerDTO(
    string Name,
    string PhoneNumber,
    string Email
) : IRequest<UpdateManagerResponse>;
