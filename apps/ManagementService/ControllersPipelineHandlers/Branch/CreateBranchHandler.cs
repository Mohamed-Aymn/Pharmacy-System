using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Branch.Create;

namespace ManagementService.ControllersPipelineHandlers.Branch;

public class CreateBranchHandler : IRequestHandler<CreateBranchDTO, CreateBranchResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Branch, string> _branchRepository;
  public CreateBranchHandler(IMapper mapper, IRepository<Models.Branch, string> branchRepository)
  {
    _mapper = mapper;
    _branchRepository = branchRepository;
  }

  public Task<CreateBranchResponse> Handle(CreateBranchDTO createBranchDTO, CancellationToken cancellationToken)
  {
    Models.Branch branch = new(
        createBranchDTO.Name,
        createBranchDTO.PhoneNumber,
        createBranchDTO.Address);
    _branchRepository.Add(branch);
    _branchRepository.SaveChangesAsync();

    return Task.FromResult(new CreateBranchResponse(branch.Name));
  }
}