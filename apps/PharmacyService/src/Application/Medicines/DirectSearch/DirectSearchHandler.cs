using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;

namespace BranchService.Application.Medicines.DirectSearch;
public class DirectSearchHandler : IRequestHandler<DirectSearchDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public DirectSearchHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(DirectSearchDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new MedicineResult();
  }
}