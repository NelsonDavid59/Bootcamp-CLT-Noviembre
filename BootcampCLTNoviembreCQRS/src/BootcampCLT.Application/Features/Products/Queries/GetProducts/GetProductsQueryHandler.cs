using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Features.Products.DTOs;
using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Application.Features.Products.Mappings;

namespace BootcampCLT.Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler(IProductRepository repository) : IQueryHandler<GetProductsQuery, ICollection<ProductResponse>>
{
    public async Task<ICollection<ProductResponse>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var result = await repository.GetAll(cancellationToken);

        //Convertimos a lista response
        return result.Select(s => s.ToResponse()).ToList();
    }
}