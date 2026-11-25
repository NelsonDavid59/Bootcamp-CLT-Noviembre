using BootcampCLT.Application.Common.CQRS;
using BootcampCLT.Application.Common.Interfaces;
using BootcampCLT.Application.Features.Products.Interfaces;

namespace BootcampCLT.Application.Features.Products.Commands.UpdateProduct;

public class UpdateMinStockCommandHandler(
    IProductRepository repository,
    IUnitOfWork unitOfWork
    ) : ICommandHandler<UpdateMinStockCommand>
{
    public async Task Handle(UpdateMinStockCommand command, CancellationToken cancellationToken)
    {
        // Obtenemos el producto existente
        var existingProduct = await repository.GetById(command.ProductId, cancellationToken);

        existingProduct.UpdateMinStock(command.NewQuantity);

        // Actualizamos el producto
        repository.Update(existingProduct);

        // Commit
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}