using MapsterMapper;
using MediatR;
using PharmacyService.Application.Branches.Common;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Application.Medicines.Create;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

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

    return new MedicineResult();
  }
}