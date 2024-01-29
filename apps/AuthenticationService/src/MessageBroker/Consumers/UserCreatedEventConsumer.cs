using AuthenticationService.Models;
using AuthenticationService.Presistence;
using ManagementService.MessageBroker.Events;
using MassTransit;

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
    // User user = new(
    //   name: context.Message.Name,
    //   email: context.Message.Email,
    //   password: context.Message.Password
    // );
    // await _userRepository.Add(user);

    _logger.LogInformation("user added successfully");

    return Task.CompletedTask;
  }
}