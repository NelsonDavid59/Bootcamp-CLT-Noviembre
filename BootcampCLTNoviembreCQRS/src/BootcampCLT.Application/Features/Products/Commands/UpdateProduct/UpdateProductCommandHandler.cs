using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Common.Interfaces;
using BootcampCLT.Application.Features.Products.DTOs;
using BootcampCLT.Application.Features.Products.Interfaces;
using BootcampCLT.Application.Features.Products.Mappings;

namespace BootcampCLT.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork) 
    : ICommandHandler<UpdateProductCommand, ProductResponse>
{
    public async Task<ProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        // Validación de existencia de producto
        var existingProduct = await repository.GetById(command.Id, cancellationToken);

        // Actualizamos los valores del producto
        existingProduct.Update(
            command.Name, 
            command.Description, 
            command.Price, 
            command.MinStock);
        
        // Llamamos al update del repository
        repository.Update(existingProduct);

        // Commit
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return existingProduct.ToResponse();
    }
}