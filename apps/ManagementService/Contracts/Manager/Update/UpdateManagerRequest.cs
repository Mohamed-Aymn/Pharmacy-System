namespace ManagementService.Contracts.Manager.Update;

public record UpdateManagerRequest(
    string Name,
    string PhoneNumber,
    string Email
);
