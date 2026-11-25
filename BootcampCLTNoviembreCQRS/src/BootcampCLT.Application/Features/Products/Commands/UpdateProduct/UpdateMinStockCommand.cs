
using BootcampCLT.Application.Common.CQRS;

namespace BootcampCLT.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateMinStockCommand(
    int ProductId,
    int NewQuantity
) : ICommand;