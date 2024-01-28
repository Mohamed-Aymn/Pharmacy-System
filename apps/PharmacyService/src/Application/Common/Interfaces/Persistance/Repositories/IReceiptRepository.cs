using PharmacyService.Application.Common.Interfaces.Persistance;

namespace PharmacyService.Application.Common.Interfaces.Persistence.Respositories;

public interface IReceiptRepository<Receipt, ReceiptId> : IRepository<Receipt, ReceiptId>
{
}