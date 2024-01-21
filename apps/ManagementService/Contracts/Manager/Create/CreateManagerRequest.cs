namespace ManagementService.Contracts.Manager.Create;

public record CreateManagerRequest(
    string Name,
    int PhoneNumber,
    string Email
);
