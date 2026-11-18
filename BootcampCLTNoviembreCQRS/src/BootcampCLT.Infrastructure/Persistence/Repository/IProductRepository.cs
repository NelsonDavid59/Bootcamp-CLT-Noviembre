using BootcampCLT.Domain.Products;

namespace BootcampCLT.Infrastructure.Persistence.Repository;

public interface IProductRepository
{
    public Task<ProductEntity> GetById(int producId);

    public Task<ICollection<ProductEntity>> GetAll();

    public void Save(ProductEntity product);

    public void Update(ProductEntity product);
}