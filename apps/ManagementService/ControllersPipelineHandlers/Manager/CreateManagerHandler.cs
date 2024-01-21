using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Models;
using ManagementService.Contracts.Manager.Create;

namespace ManagementService.ControllersPipelineHandlers.Manager;

public class CreateOrderCommandHandler : IRequestHandler<CreateManagerDTO, CreateManagerResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Manager, string> _managerRepository;
  public CreateOrderCommandHandler(IMapper mapper, IRepository<Models.Manager, string> managerRepository)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public Task<CreateManagerResponse> Handle(CreateManagerDTO createManagerDTO, CancellationToken cancellationToken)
  {
    Models.Manager manager = new(
        createManagerDTO.Name,
        createManagerDTO.PhoneNumber,
        createManagerDTO.Email);
    _managerRepository.Add(manager);
    _managerRepository.SaveChangesAsync();

    return Task.FromResult(new CreateManagerResponse(manager.Name));
  }
}