using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Receipts.Common;

namespace PharmacyService.Application.Receipts.ReturnReceipt;

public class ReturnReceiptHandler : IRequestHandler<ReturnReceiptDto, ReceiptResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public ReturnReceiptHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<ReceiptResult> Handle(ReturnReceiptDto request, CancellationToken cancellationToken)
  {

    // trigger event here

    return new ReceiptResult();
  }
}