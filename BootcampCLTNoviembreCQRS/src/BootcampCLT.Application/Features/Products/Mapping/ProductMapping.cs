using BootcampCLT.Application.Features.Products.DTOs;
using BootcampCLT.Domain.Products;

namespace BootcampCLT.Application.Features.Products.Mappings;

public static class ProductMappings
{
    public static ProductResponse ToResponse(this ProductEntity product)
    {
        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.MinStock,
            product.CreatedAt,
            product.UpdatedAt);
    }
}