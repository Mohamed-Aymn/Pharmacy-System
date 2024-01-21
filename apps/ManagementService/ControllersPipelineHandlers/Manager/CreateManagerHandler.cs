using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Models;
using ManagementService.Contracts.Manager.Create;

namespace ManagementService.ControllersPipelineHandlers.Manager;

public class CreateOrderCommandHandler : IRequestHandler<CreateManagerDTO, CreateManagerResponse>
{
  private readonly IMapper _mapper;
  private readonly Repository<ManagementService.Models.Manager, string> _managerRepository;
  public CreateOrderCommandHandler(IMapper mapper, Repository<Models.Manager, string> managerRepository)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public Task<CreateManagerResponse> Handle(CreateManagerDTO request, CancellationToken cancellationToken)
  {
    ManagementService.Models.Manager manager = new(
        request.Name,
        request.PhoneNumber,
        request.Email);
    _managerRepository.Add(manager);

    return Task.FromResult(new CreateManagerResponse(manager.Name));
  }
}