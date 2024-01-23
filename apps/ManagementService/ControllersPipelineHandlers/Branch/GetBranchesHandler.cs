using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Branch.Get;

namespace ManagementService.ControllersPipelineHandlers.Branches;

public class GetBranchesHandler : IRequestHandler<GetBranchesRequest, IEnumerable<GetBranchResponse>>
{
  private readonly IRepository<Models.Branch, string> _branchRepository;
  private readonly IMapper _mapper;
  public GetBranchesHandler(IRepository<Models.Branch, string> branchRepository, IMapper mapper)
  {
    _mapper = mapper;
    _branchRepository = branchRepository;
  }

  public async Task<IEnumerable<GetBranchResponse>> Handle(GetBranchesRequest request, CancellationToken cancellationToken)
  {
    var branches = await _branchRepository.GetAllAsync();
    return branches.Select(branch => _mapper.Map<GetBranchResponse>(branch));
  }
}