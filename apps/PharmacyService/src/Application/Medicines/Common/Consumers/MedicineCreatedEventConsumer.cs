using MassTransit;
using Microsoft.Extensions.Logging;
using SharedKernel.Events;

namespace PharmacyService.Application.Medicines.Common.Consumers;

public class MedicineCreatedEventConsumer : IConsumer<MedicineCreatedEvent>
{
  private readonly ILogger<MedicineCreatedEventConsumer> _logger;

  public MedicineCreatedEventConsumer(ILogger<MedicineCreatedEventConsumer> logger)
  {
    _logger = logger;
  }

  public Task Consume(ConsumeContext<MedicineCreatedEvent> context)
  {
    return Task.CompletedTask;
  }
}