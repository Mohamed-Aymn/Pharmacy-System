using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Application.Medicines.Create;

namespace PharmacyService.Application.Branches.Create;

public class DispenseMedicineHandler : IRequestHandler<DispenseMedicineDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public DispenseMedicineHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(DispenseMedicineDto request, CancellationToken cancellationToken)
  {

    // trigger event here
    var id = request.PharmacistId.Value;

    return new MedicineResult();
  }
}