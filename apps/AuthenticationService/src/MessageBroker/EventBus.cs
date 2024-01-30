using MassTransit;

namespace AuthenticationService.MessageBroker;

public sealed class EventBus : IEventBus
{

  private readonly IPublishEndpoint _publishEndpoint;

  public EventBus(IPublishEndpoint publishEndpoint)
  {
    _publishEndpoint = publishEndpoint;
  }

  public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
  {
    await _publishEndpoint.Publish<T>(message, cancellationToken);
  }
}