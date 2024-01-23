using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Medicine.Update;

namespace ManagementService.ControllersPipelineHandlers.Medicine;

public class UpdateMedicineHandler : IRequestHandler<UpdateMedicineDTO, UpdateMedicineResponse>
{
  private readonly IRepository<Models.Medicine, string> _managerRepository;
  public UpdateMedicineHandler(IRepository<Models.Medicine, string> managerRepository)
  {
    _managerRepository = managerRepository;
  }

  public async Task<UpdateMedicineResponse> Handle(UpdateMedicineDTO request, CancellationToken cancellationToken)
  {
    var existingMedicine = await _managerRepository.GetByIdAsync(request.Name);

    if (existingMedicine is null)
    {
      throw new Exception();
    }

    existingMedicine.Name = request.Name;
    existingMedicine.BarCode = request.BarCode;
    _managerRepository.Update(existingMedicine);
    await _managerRepository.SaveChangesAsync();

    return new UpdateMedicineResponse(existingMedicine.Name);
  }
}