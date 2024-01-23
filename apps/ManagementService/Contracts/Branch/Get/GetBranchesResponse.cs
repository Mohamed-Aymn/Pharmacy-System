namespace ManagementService.Contracts.Branch.Get;

public record GetBranchResponse(
  string Name,
  string Email,
  string Address
);
