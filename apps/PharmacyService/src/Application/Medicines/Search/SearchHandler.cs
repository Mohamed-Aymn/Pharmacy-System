using MapsterMapper;
using MediatR;
using PharmacyService.Application.Branches.Common;
using PharmacyService.Application.Branches.Create;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.Search;

public class SearchHandler : IRequestHandler<SearchDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public SearchHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(SearchDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new MedicineResult();
  }
}