using MediatR;

namespace ManagementService.Contracts.Branch.Get;

public record GetBranchesRequest() : IRequest<IEnumerable<GetBranchResponse>>;
