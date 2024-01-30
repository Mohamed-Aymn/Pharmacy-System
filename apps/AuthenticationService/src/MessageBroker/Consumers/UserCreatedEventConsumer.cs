using AuthenticationService.Presistence;
using MassTransit;
using SharedKernel.Events;

namespace ManagementService.MessageBroker.Consumers;

public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
  private readonly ILogger<UserCreatedEventConsumer> _logger;
  private readonly IUserRepository _userRepository;

  public UserCreatedEventConsumer(ILogger<UserCreatedEventConsumer> logger, IUserRepository userRepository)
  {
    _logger = logger;
    _userRepository = userRepository;
  }

  public Task Consume(ConsumeContext<UserCreatedEvent> context)
  {

    _logger.LogInformation("user added successfully");

    return Task.CompletedTask;
  }
}