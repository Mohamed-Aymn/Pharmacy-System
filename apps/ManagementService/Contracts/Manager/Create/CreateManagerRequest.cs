namespace ManagementService.Contracts.Manager.Create;

public record CreateManagerRequest(
    string Name,
    string PhoneNumber,
    string Email
);
