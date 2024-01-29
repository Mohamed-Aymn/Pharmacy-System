using ManagementService.MessageBroker.Events;
using ManagementService.Persistence;
using MassTransit;

namespace ManagementService.MessageBroker.Consumers;

public class BranchCreatedEventConsumer : IConsumer<BranchCreatedEvent>
{
  private readonly ILogger<BranchCreatedEventConsumer> _logger;

  public BranchCreatedEventConsumer(ILogger<BranchCreatedEventConsumer> logger)
  {
    _logger = logger;
  }

  public Task Consume(ConsumeContext<BranchCreatedEvent> context)
  {

    _logger.LogInformation("Branch event consumed");

    return Task.CompletedTask;
  }

}