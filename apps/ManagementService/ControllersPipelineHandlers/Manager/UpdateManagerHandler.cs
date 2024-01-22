using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Manager.Update;

namespace ManagementService.ControllersPipelineHandlers.Manager;

public class UpdateManagerHandler : IRequestHandler<UpdateManagerDTO, UpdateManagerResponse>
{
  private readonly IRepository<Models.Manager, string> _managerRepository;
  public UpdateManagerHandler(IRepository<Models.Manager, string> managerRepository)
  {
    _managerRepository = managerRepository;
  }

  public async Task<UpdateManagerResponse> Handle(UpdateManagerDTO request, CancellationToken cancellationToken)
  {
    var existingManager = await _managerRepository.GetByIdAsync(request.Name);

    if (existingManager is not null)
    {
      existingManager.PhoneNumber = request.PhoneNumber;
      existingManager.Email = request.Email;
      _managerRepository.Update(existingManager);
      await _managerRepository.SaveChangesAsync();
    }

    return new UpdateManagerResponse(existingManager.Name);
  }
}