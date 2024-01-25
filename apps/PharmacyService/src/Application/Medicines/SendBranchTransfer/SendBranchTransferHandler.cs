using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Medicines.Common;

namespace PharmacyService.Application.Medicines.SendBranchTransfer;
public class SendBranchTransferHandler : IRequestHandler<SendBranchTransferDto, MedicineResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public SendBranchTransferHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<MedicineResult> Handle(SendBranchTransferDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new MedicineResult();
  }
}