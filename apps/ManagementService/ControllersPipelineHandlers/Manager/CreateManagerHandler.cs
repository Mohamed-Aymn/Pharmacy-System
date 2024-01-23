using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Manager.Create;

namespace ManagementService.ControllersPipelineHandlers.Manager;

public class CreateManagerHandler : IRequestHandler<CreateManagerDTO, CreateManagerResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Manager, string> _managerRepository;
  public CreateManagerHandler(IMapper mapper, IRepository<Models.Manager, string> managerRepository)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public async Task<CreateManagerResponse> Handle(CreateManagerDTO createManagerDTO, CancellationToken cancellationToken)
  {
    Models.Manager manager = new(
        createManagerDTO.Name,
        createManagerDTO.PhoneNumber,
        createManagerDTO.Email);
    _managerRepository.Add(manager);
    await _managerRepository.SaveChangesAsync();

    return await Task.FromResult(new CreateManagerResponse(manager.Name));
  }
}