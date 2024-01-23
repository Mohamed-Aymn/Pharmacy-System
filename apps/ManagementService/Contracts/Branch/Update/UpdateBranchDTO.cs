using MediatR;

namespace ManagementService.Contracts.Branch.Update;

public record UpdateBranchDTO(
    string Name,
    string PhoneNumber,
    string Address
) : IRequest<UpdateBranchResponse>;
