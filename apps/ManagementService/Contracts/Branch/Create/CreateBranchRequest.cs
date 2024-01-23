namespace ManagementService.Contracts.Branch.Create;

public record CreateBranchRequest(
    string Name,
    string PhoneNumber,
    string Address 
);
