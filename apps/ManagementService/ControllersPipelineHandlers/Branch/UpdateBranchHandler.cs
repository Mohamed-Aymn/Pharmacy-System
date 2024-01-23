using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Branch.Update;

namespace ManagementService.ControllersPipelineHandlers.Branch;

public class UpdateBranchHandler : IRequestHandler<UpdateBranchDTO, UpdateBranchResponse>
{
  private readonly IRepository<Models.Branch, string> _branchRepository;
  public UpdateBranchHandler(IRepository<Models.Branch, string> branchRepository)
  {
    _branchRepository = branchRepository;
  }

  public async Task<UpdateBranchResponse> Handle(UpdateBranchDTO request, CancellationToken cancellationToken)
  {

    var existingBranch = await _branchRepository.GetByIdAsync(request.Name);

    if (existingBranch is not null)
    {
      existingBranch.PhoneNumber = request.PhoneNumber;
      existingBranch.Address = request.Address;
      _branchRepository.Update(existingBranch);
      await _branchRepository.SaveChangesAsync();
    }

    return new UpdateBranchResponse(existingBranch.Name);
  }
}