using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Products.DTOs;

namespace BootcampCLT.Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    int Id,
    string Name,
    string? Description,
    decimal Price,
    int MinStock
) : ICommand<ProductResponse>;