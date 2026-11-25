using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Products.DTOs;

namespace BootcampCLT.Application.Features.Products.Queries.GetProducts;

public sealed record GetProductQuery(
    int ProductId
) : IQuery<ProductResponse>;