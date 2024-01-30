namespace SharedKernel.Events;

public record UserCreatedEvent(
    string Name,
    string Password,
    string Email
);