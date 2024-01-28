using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;

namespace PharmacyService.Application.Medicines.BranchesSearch;

public class BranchesSearchHandler : IRequestHandler<BranchesSearchDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public BranchesSearchHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(BranchesSearchDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new MedicineResult();
  }
}