namespace ManagementService.Contracts.Branch.Update;

public record UpdateBranchRequest(
    string Name,
    string PhoneNumber,
    string Email
);
