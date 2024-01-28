using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;

namespace PharmacyService.Application.Medicines.ReceiveBranchTransfer;

public class ReceiveBranchTransferHandler : IRequestHandler<ReceiveBranchTransferDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public ReceiveBranchTransferHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(ReceiveBranchTransferDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new MedicineResult();
  }
}