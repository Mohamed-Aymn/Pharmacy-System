using MassTransit;

namespace ManagementService.MessageBroker;

public sealed class EventBus : IEventBus
{

  private readonly IPublishEndpoint _publishEndpoint;
  private readonly ILogger<EventBus> _logger;

  public EventBus(IPublishEndpoint publishEndpoint, ILogger<EventBus> logger)
  {
    _publishEndpoint = publishEndpoint;
    _logger = logger;
  }

  public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
  {
    _logger.LogInformation("event published");
    await _publishEndpoint.Publish<T>(message, cancellationToken);
  }
}