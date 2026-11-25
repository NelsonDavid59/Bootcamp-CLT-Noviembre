using BootcampCLT.Domain.Products;

namespace BootcampCLT.Application.Features.Products.Interfaces;

public interface IProductRepository
{
    public Task<ProductEntity> GetById(int producId, CancellationToken cancellationToken);

    public Task<ICollection<ProductEntity>> GetAll(CancellationToken cancellationToken);

    public void Save(ProductEntity product);

    public void Update(ProductEntity product);
}