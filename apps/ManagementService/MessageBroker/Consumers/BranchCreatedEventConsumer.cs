using ManagementService.MessageBroker.Events;
using MassTransit;

namespace ManagementService.MessageBroker.Consumers;

public class UserCreatedEventConsumer : IConsumer<UserCreatedEvent>
{
  private readonly ILogger<UserCreatedEventConsumer> _logger;

  public UserCreatedEventConsumer(ILogger<UserCreatedEventConsumer> logger)
  {
    _logger = logger;
  }

  public Task Consume(ConsumeContext<UserCreatedEvent> context)
  {


    return Task.CompletedTask;
  }
}