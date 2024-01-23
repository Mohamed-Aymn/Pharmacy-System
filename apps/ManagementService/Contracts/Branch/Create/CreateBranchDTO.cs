using MediatR;

namespace ManagementService.Contracts.Branch.Create;

public record CreateBranchDTO(
    string Name,
    string PhoneNumber,
    string Address
) : IRequest<CreateBranchResponse>;
