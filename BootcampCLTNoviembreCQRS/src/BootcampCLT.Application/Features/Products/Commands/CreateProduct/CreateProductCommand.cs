using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Products.DTOs;

namespace BootcampCLT.Application.Features.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name, 
    string? Description,
    decimal Price,
    int MinStock
) : ICommand<ProductResponse>;