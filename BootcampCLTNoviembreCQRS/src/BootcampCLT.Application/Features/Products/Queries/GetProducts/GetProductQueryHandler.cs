using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Products.DTOs;
using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Application.Features.Products.Mappings;

namespace BootcampCLT.Application.Features.Products.Queries.GetProducts;

public class GetProductQueryHandler(IProductRepository repository) : IQueryHandler<GetProductQuery, ProductResponse>
{
    public async Task<ProductResponse> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var product = await repository.GetById(query.ProductId, cancellationToken);
        
        return product.ToResponse();
    }
}