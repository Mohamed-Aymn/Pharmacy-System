using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Branch.Create;
using ManagementService.MessageBroker;
using ManagementService.MessageBroker.Events;

namespace ManagementService.ControllersPipelineHandlers.Branch;

public class CreateBranchHandler : IRequestHandler<CreateBranchDTO, CreateBranchResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Branch, string> _branchRepository;
  private readonly IEventBus _eventBus;
  public CreateBranchHandler(IMapper mapper, IRepository<Models.Branch, string> branchRepository, IEventBus eventBus)
  {
    _mapper = mapper;
    _branchRepository = branchRepository;
    _eventBus = eventBus;
  }

  public async Task<CreateBranchResponse> Handle(CreateBranchDTO createBranchDTO, CancellationToken cancellationToken)
  {
    Models.Branch branch = new(
        createBranchDTO.Name,
        createBranchDTO.PhoneNumber,
        createBranchDTO.Address);
    _branchRepository.Add(branch);
    await _branchRepository.SaveChangesAsync();

    await _eventBus.PublishAsync(new BranchCreatedEvent(createBranchDTO.Name), cancellationToken);

    return await Task.FromResult(new CreateBranchResponse(branch.Name));
  }
}