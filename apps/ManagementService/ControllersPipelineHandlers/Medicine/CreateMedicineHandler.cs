using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Medicine.Create;

namespace ManagementService.ControllersPipelineHandlers.Medicine;

public class CreateMedicineHandler : IRequestHandler<CreateMedicineDTO, CreateMedicineResponse>
{
  private readonly IMapper _mapper;
  private readonly IRepository<Models.Medicine, string> _managerRepository;
  public CreateMedicineHandler(IMapper mapper, IRepository<Models.Medicine, string> managerRepository)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public async Task<CreateMedicineResponse> Handle(CreateMedicineDTO createMedicineDTO, CancellationToken cancellationToken)
  {
    Models.Medicine medicine = new(
        createMedicineDTO.Name,
        createMedicineDTO.Concentration,
        createMedicineDTO.BarCode,
        createMedicineDTO.MedicineType);
    _managerRepository.Add(medicine);
    await _managerRepository.SaveChangesAsync();

    return await Task.FromResult(new CreateMedicineResponse(medicine.Name));
  }
}