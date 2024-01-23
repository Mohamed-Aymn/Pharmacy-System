using MediatR;

namespace ManagementService.Contracts.Medicine.Get;

public record GetMedicinesRequest() : IRequest<IEnumerable<GetMedicinesResponse>>;
