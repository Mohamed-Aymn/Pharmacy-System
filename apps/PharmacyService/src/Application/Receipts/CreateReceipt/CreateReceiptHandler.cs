using MapsterMapper;
using MediatR;
using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Application.Receipts.Common;

namespace PharmacyService.Application.Receipts.CreateReceipt;

public class CreateReceiptHandler : IRequestHandler<CreateReceiptDto, ReceiptResult>
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;
  public CreateReceiptHandler(IMapper mapper, IUnitOfWork unitOfWork)
  {
    _mapper = mapper;
    _unitOfWork = unitOfWork;
  }

  public async Task<ReceiptResult> Handle(CreateReceiptDto request, CancellationToken cancellationToken)
  {
    // trigger event here

    return new ReceiptResult();
  }
}