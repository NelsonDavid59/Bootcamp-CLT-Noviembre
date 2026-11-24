using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Common.Interfaces;
using BootcampCLT.Application.Features.Products.DTOs;
using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Domain.Products;

namespace BootcampCLT.Application.Features.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Creamos el producto
        var product = ProductEntity.Create(command.Name, command.Description, command.Price, command.MinStock);

        // Agregamos el producto con repository
        productRepository.Save(product);

        // Commit
        await unitOfWork.SaveChangesAsync(cancellationToken);

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