namespace ManagementService.MessageBroker.Events;

public record UserCreatedEvent(
    string Name,
    string Password,
    string Email
);